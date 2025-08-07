using Godot;
using System;

[GlobalClass]
public partial class DamageStat : Resource
{
    [Export]
    public float DamageAmount { get; set; }

    // [Export]
    // public DataType.DamageType DamageType { get; set; }
}
