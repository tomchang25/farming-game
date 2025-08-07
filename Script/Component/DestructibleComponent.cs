using Godot;
using System;

public partial class DestructibleComponent : StaticBody2D
{
    [Export]
    public DestructibleStat DestructibleStat { get; set; }
    private HealthComponent healthComponent;
    private HurtComponent hurtComponent;
    private ShakeComponent shakeComponent;
    private PackedScene spawnScene;

    public override void _Ready()
    {
        this.healthComponent = this.GetNode<HealthComponent>("HealthComponent");
        this.hurtComponent = this.GetNode<HurtComponent>("HurtComponent");
        this.hurtComponent.Connect("Hurt", new Callable(this, nameof(OnHurt)));

        this.healthComponent.Connect("HealthChanged", new Callable(this, nameof(OnHealthChanged)));
        this.healthComponent.Connect("HealthDepleted", new Callable(this, nameof(OnHealthDepleted)));

        this.healthComponent.SetMaxHealth(this.DestructibleStat.HealthAcount);
        this.hurtComponent.AllowedDamageType = this.DestructibleStat.AllowedDamageType;
        this.spawnScene = this.DestructibleStat.SpawnScene;

        if (this.GetNodeOrNull<ShakeComponent>("ShakeComponent") is ShakeComponent shakeComponent)
        {
            this.shakeComponent = shakeComponent;
        }
    }

    private void OnHealthDepleted()
    {
        this.CallDeferred("SpawnLog");
        this.QueueFree();
    }

    private void OnHurt(DamageStat damage)
    {
        this.healthComponent.TakeDamage(damage.DamageAmount);

        if (this.DestructibleStat.IsShakable && this.shakeComponent != null)
        {
            this.shakeComponent.Shake(this.DestructibleStat.ShakeDuration, this.DestructibleStat.ShakeIntensity);
        }

    }

    private void OnHealthChanged(float health)
    {
        GD.Print("Health: " + health);
    }

    private void SpawnLog()
    {
        Node2D log = this.spawnScene.Instantiate() as Node2D;
        log.GlobalPosition = this.GlobalPosition;
        this.GetParent().AddChild(log);
    }


}
