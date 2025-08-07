using Godot;
using System;

public partial class InteractableComponent : Area2D
{
    [Signal]
    public delegate void InteractableActivatedEventHandler();

    [Signal]
    public delegate void InteractableDeactivatedEventHandler();

    public override void _Ready()
    {
        base._Ready();
        this.Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
        this.Connect("body_exited", new Callable(this, nameof(OnBodyExited)));
    }

    private void OnBodyEntered(Node body)
    {
        if (body.IsInGroup("Player"))
        {
            this.EmitSignal("InteractableActivated");
        }
    }

    private void OnBodyExited(Node body)
    {
        if (body.IsInGroup("Player"))
        {
            this.EmitSignal("InteractableDeactivated");
        }
    }
}
