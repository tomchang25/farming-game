using Godot;
using System;

public partial class HitComponent : Area2D
{
    [Signal]
    public delegate void HitEventHandler(HurtComponent hurtComponent);
    public override void _Ready()
    {
        base._Ready();
        this.Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is HurtComponent hurtComponent)
        {
            this.EmitSignal("Hit", hurtComponent);
        }
    }
}
