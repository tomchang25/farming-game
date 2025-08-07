using Godot;
using System;
using System.Collections.Generic;

public partial class NodeStateMachine : Node
{
    [Export]
    public NodeState InitialNodeState { get; set; }

    private Dictionary<Variant, NodeState> nodeStates = [];
    private NodeState currentNodeState;

    public override void _Ready()
    {

        foreach (Node child in this.GetChildren())
        {
            if (child is NodeState nodeState)
            {
                if (this.nodeStates.ContainsKey(nodeState.StateType))
                {
                    GD.PushError("Duplicate node state type: " + nodeState.StateType + " in " + nodeState.Name);
                }

                this.nodeStates[nodeState.StateType] = nodeState;
                nodeState.StateTransitioned += this.TransitionTo;
            }
        }

        if (this.InitialNodeState != null)
        {
            this.CallDeferred("Init");
        }

    }

    private void Init()
    {
        this.InitialNodeState.OnEnter();
        this.currentNodeState = this.InitialNodeState;
    }

    public override void _Process(double delta)
    {
        if (this.currentNodeState != null)
        {
            this.currentNodeState.OnProcess(delta);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (this.currentNodeState != null)
        {
            this.currentNodeState.OnPhysicsProcess(delta);
            this.currentNodeState.OnNextTransition();
        }
    }

    private void TransitionTo(NodeState fromNodeState, Variant nextNodeStateType)
    {
        if (!this.nodeStates.TryGetValue(nextNodeStateType, out NodeState nextNodeState))
        {
            GD.PushError("Node state not found: " + nextNodeStateType);
            return;
        }

        if (fromNodeState != this.currentNodeState)
        {
            GD.PushError("Unmatched node state transition: " + fromNodeState.Name + " -> " + nextNodeState.Name + " (expected: " + this.currentNodeState.Name + ")");
            return;
        }


        if (this.currentNodeState == nextNodeState)
        {
            return;
        }

        // GD.Print("Transitioning from " + this.currentNodeState.Name + " to " + nextNodeState.Name);

        this.currentNodeState.OnExit();
        nextNodeState.OnEnter();

        this.currentNodeState = nextNodeState;

        // GD.Print("Current State: " + _currentNodeStateName);
    }
}
