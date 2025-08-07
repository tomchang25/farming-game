using Godot;
using System;

[GlobalClass]
public partial class DestructibleStat : Resource
{
    [Export]
    public int HealthAcount { get; set; }

    [Export]
    public DataType.DamageType AllowedDamageType { get; set; }

    [Export]
    public PackedScene SpawnScene { get; set; }

    [Export]
    public bool IsShakable { get; set; }

    [Export]
    public float ShakeIntensity { get; set; }

    [Export]
    public float ShakeDuration { get; set; }

}

