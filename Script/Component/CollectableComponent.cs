using Godot;
using System;

public partial class CollectableComponent : Area2D
{
    // [Signal]
    // public delegate void CollectableCollectedEventHandler();
    public override void _Ready()
    {
        this.Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
    }

    private void OnBodyEntered(Node body)
    {
        if (body.IsInGroup("Player"))
        {
            // GD.Print("Collectable collected");
            this.Owner.QueueFree();
        }
    }
}
