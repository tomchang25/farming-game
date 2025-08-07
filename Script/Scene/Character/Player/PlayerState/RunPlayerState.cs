using Godot;
using System;

public partial class RunPlayerState : PlayerState
{

    public override int StateType => (int)PlayerStateType.Run;

    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta)
    {
        Vector2 direction = InputManager.MovementInput();
        if (direction != Vector2.Zero)
        {
            this.PlayerNode.UpdateDirection(direction);
        }

    }
    public override void OnNextTransition()
    {
        if (!InputManager.IsRunInput())
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Walk);
        }
        else if (!InputManager.IsMovementInput())
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Idle);
        }

        // if (Input.IsActionPressed("Tool"))
        // {
        //     this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Chopping);
        // }
    }
    public override void OnEnter()
    {
        this.PlayerNode.SetSpeed(PlayerStateType.Run);
        this.PlayerNode.UpdateAnimation(PlayerStateType.Run);
    }
    public override void OnExit() { }


}
