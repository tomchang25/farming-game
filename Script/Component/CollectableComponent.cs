using Godot;
using System;

public partial class CollectableComponent : Area2D
{
    // [Signal]
    // public delegate void CollectableCollectedEventHandler();

    [Export]
    public CollectableStat collectableStat;
    public override void _Ready()
    {
        this.Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
    }

    private void OnBodyEntered(Node body)
    {
        if (body is Player player && player.IsInGroup("Player"))
        {
            bool collected = player.AddInventory(this.collectableStat);
            if (collected)
            {
                this.Owner.QueueFree();
            }

        }
    }
}
