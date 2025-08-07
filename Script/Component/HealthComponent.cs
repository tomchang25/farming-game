using Godot;
using System;

public partial class HealthComponent : Node
{
    [Signal]
    public delegate void HealthChangedEventHandler(float health);

    [Signal]
    public delegate void HealthDepletedEventHandler();


    [Export]
    public float MaxHealth { get; set; }

    [Export]
    public float CurrentHealth { get; set; }

    public override void _Ready()
    {
        this.CurrentHealth = this.MaxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.MaxHealth = maxHealth;
        this.CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }

        if (this.CurrentHealth <= 0)
        {
            return;
        }

        this.CurrentHealth -= damage;
        this.EmitSignal("HealthChanged", this.CurrentHealth);
        if (this.CurrentHealth <= 0)
        {
            this.EmitSignal("HealthDepleted");
        }
    }
}
