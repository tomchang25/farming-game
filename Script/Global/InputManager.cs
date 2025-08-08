using Godot;
using System;

public partial class InputManager : Node
{
    public static bool IsMouseOverUI { get; private set; }

    public static Vector2 MovementInput()
    {
        return Input.GetVector("Left", "Right", "Up", "Down");
    }

    public static bool IsMovementInput()
    {
        return MovementInput() != Vector2.Zero;
    }

    public static bool IsRunInput()
    {
        return Input.IsActionPressed("Run");
    }

    public static bool IsUseTool()
    {

        return Input.IsActionPressed("Hit") && !IsMouseOverUI;

    }

    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);
        if (@event is InputEventMouseButton button && button.ButtonIndex == MouseButton.Right)
        {
            SignalManager.Instance.EmitSignal("ToolDeselected");
            return;
        }
        if (@event is InputEventMouseMotion or InputEventMouseButton)
        {
            IsMouseOverUI = this.GetViewport().GuiGetHoveredControl() != null;
            // GD.Print(this.GetViewport().GuiGetHoveredControl());
        }

    }
}
