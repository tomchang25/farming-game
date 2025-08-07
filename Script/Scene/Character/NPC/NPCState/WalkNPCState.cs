using Godot;
using System;

public partial class WalkNPCState : NPCState
{
    public override int StateType => (int)NPCStateType.Walk;

    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnNextTransition()
    {
        if (!this.NPCNode.IsMoving())
        {
            this.EmitSignal("StateTransitioned", this, (int)NPCStateType.Idle);
        }

    }
    public override void OnEnter()
    {
        // GD.Print("WalkNPCState OnEnter");
        this.NPCNode.SetSpeed(NPCStateType.Walk);
        this.NPCNode.UpdateTargetPosition();
        this.NPCNode.UpdateAnimation(NPCStateType.Walk);
    }
    public override void OnExit() { }


}
