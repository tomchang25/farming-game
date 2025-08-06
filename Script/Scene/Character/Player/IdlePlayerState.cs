using Godot;
using System;

public partial class IdlePlayerState : PlayerState
{
    public override int StateType => (int)PlayerStateType.Idle;

    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnNextTransition()
    {
        if (InputManager.IsMovementInput())
        {
            this.EmitSignal("StateTransitioned", this, (int)PlayerStateType.Walk);
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
        this.PlayerNode.SetSpeed(PlayerStateType.Idle);
        this.PlayerNode.UpdateAnimation(PlayerStateType.Idle);
    }
    public override void OnExit() { }


}
