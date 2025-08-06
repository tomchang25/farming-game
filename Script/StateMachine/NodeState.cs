using Godot;
using System;

public abstract partial class NodeState : Node
{

    [Signal]
    public delegate void StateTransitionedEventHandler(NodeState fromNodeState, Variant nextNodeStateType);
    public abstract int StateType { get; }
    private int nextNodeStateType = -1;


    public virtual void OnProcess(double delta) { }
    public virtual void OnPhysicsProcess(double delta) { }

    // Using if / else if / else to prevent multiple transitions
    public virtual void OnNextTransition() { }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }

    public override bool Equals(object obj)
    {
        if (obj is not NodeState other)
        {
            return false;
        }

        return this.StateType.Equals(other.StateType);
    }

    public override int GetHashCode()
    {
        // Combine name and type hash for uniqueness
        return this.StateType.GetHashCode();
    }

    public static bool operator ==(NodeState a, NodeState b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(NodeState a, NodeState b)
    {
        return !(a == b);
    }

}
