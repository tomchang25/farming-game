using Godot;
using Godot.Collections;
using System;

public partial class SignalManager : Node
{
    [Signal] public delegate void ToolSelectedEventHandler(DataType.ToolType toolType);
    [Signal] public delegate void ToolDeselectedEventHandler();

    [Signal] public delegate void InventoryChangedEventHandler(Dictionary inventory);

    public static SignalManager Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }


}
