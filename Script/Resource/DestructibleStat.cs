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
}
