using Godot;
using System;

public partial class HitComponent : Area2D
{
    [Export]
    public DamageStat Damage { get; set; }
    public override void _Ready()
    {
        base._Ready();
        this.Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is HurtComponent hurtComponent)
        {
            hurtComponent.OnHurt(this.Damage);
        }
    }
}
