using Godot;
using System;

public partial class InputManager : Node
{
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
        return Input.IsActionPressed("Hit");
    }
}
