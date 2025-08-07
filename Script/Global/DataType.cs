using Godot;
using System;

public static class DataType
{
    public enum ToolType
    {
        None,
        Axe,
        Hoe,
        WateringCan,
        PlantCornSeed,
        PlantTomatoSeed
    }

    public enum DamageType
    {
        None,
        AxeChopping,
        HoeTilling,
        Watering
    }
}
