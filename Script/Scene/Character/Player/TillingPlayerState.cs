using Godot;
using System;

public partial class TillingPlayerState : PlayerState
{
    public override int StateType => (int)PlayerStateType.Tilling;

    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnNextTransition()
    {
        if (this.PlayerNode.CurrentAnimation != "Tilling")
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Idle);
        }
    }
    public override void OnEnter()
    {
        this.PlayerNode.UpdateAnimation(PlayerStateType.Tilling);
        this.PlayerNode.SetSpeed(PlayerStateType.Tilling);
    }
    public override void OnExit() { }


}
