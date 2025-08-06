using Godot;
using System;

public partial class ChoppingPlayerState : PlayerState
{
    public override int StateType => (int)PlayerStateType.Chopping;

    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnNextTransition()
    {
        if (this.PlayerNode.CurrentAnimation != "Chopping")
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Idle);
        }
    }
    public override void OnEnter()
    {
        this.PlayerNode.UpdateAnimation(PlayerStateType.Chopping);
        this.PlayerNode.SetSpeed(PlayerStateType.Chopping);
    }
    public override void OnExit() { }


}
