using Godot;
using System;

public partial class WateringPlayerState : PlayerState
{
    public override int StateType => (int)PlayerStateType.Watering;

    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnNextTransition()
    {
        if (this.PlayerNode.CurrentAnimation != "Watering")
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Idle);
        }
    }
    public override void OnEnter()
    {
        this.PlayerNode.UpdateAnimation(PlayerStateType.Watering);
        this.PlayerNode.SetSpeed(PlayerStateType.Watering);
    }
    public override void OnExit() { }


}
