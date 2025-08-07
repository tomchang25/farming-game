using Godot;
using System;

public partial class HurtComponent : Area2D
{
    [Signal]
    public delegate void HurtEventHandler(DamageStat damage);
    [Export]
    public DataType.DamageType AllowedDamageType { get; set; }

    public void OnHurt(DamageStat damage)
    {
        if (damage.DamageType == this.AllowedDamageType)
        {
            this.EmitSignal("Hurt", damage);
        }
    }
}
