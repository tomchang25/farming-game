using Godot;
using System;

public partial class WalkPlayerState : PlayerState
{
    public override int StateType => (int)PlayerStateType.Walk;

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
        if (Input.IsActionPressed("Run"))
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Run);
        }
        else if (!InputManager.IsMovementInput())
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Idle);
        }
        else if (InputManager.IsUseTool() && this.PlayerNode.CurrentTool == DataType.ToolType.Axe)
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Chopping);
        }
        else if (InputManager.IsUseTool() && this.PlayerNode.CurrentTool == DataType.ToolType.Hoe)
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Tilling);
        }
        else if (InputManager.IsUseTool() && this.PlayerNode.CurrentTool == DataType.ToolType.WateringCan)
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Watering);
        }
    }
    public override void OnEnter()
    {
        this.PlayerNode.SetSpeed(PlayerStateType.Walk);
        this.PlayerNode.UpdateAnimation(PlayerStateType.Walk);
    }
    public override void OnExit() { }


}
