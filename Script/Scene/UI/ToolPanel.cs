using Godot;
using System;

public partial class ToolPanel : PanelContainer
{
    private Button ToolAxeButton { get; set; }
    private Button ToolHoeButton { get; set; }
    private Button ToolWateringCanButton { get; set; }
    private Button ToolCornSeedButton { get; set; }
    private Button ToolTomatoSeedButton { get; set; }

    public override void _Ready()
    {
        this.ToolAxeButton = this.GetNode<Button>("MarginContainer/HBoxContainer/ToolAxe");
        this.ToolHoeButton = this.GetNode<Button>("MarginContainer/HBoxContainer/ToolHoe");
        this.ToolWateringCanButton = this.GetNode<Button>("MarginContainer/HBoxContainer/ToolWateringCan");
        this.ToolCornSeedButton = this.GetNode<Button>("MarginContainer/HBoxContainer/ToolCornSeed");
        this.ToolTomatoSeedButton = this.GetNode<Button>("MarginContainer/HBoxContainer/ToolTomatoSeed");

        this.ToolAxeButton.Connect("pressed", new Callable(this, nameof(OnToolAxeButtonPressed)));
        this.ToolHoeButton.Connect("pressed", new Callable(this, nameof(OnToolHoeButtonPressed)));
        this.ToolWateringCanButton.Connect("pressed", new Callable(this, nameof(OnToolWateringCanButtonPressed)));
        this.ToolCornSeedButton.Connect("pressed", new Callable(this, nameof(OnToolCornSeedButtonPressed)));
        this.ToolTomatoSeedButton.Connect("pressed", new Callable(this, nameof(OnToolTomatoSeedButtonPressed)));

        this.ToolAxeButton.GrabFocus();

        SignalManager.Instance.Connect("ToolDeselected", new Callable(this, nameof(OnToolDeselected)));
    }

    private void OnToolAxeButtonPressed()
    {
        SignalManager.Instance.EmitSignal("ToolSelected", (int)DataType.ToolType.Axe);
    }

    private void OnToolHoeButtonPressed()
    {
        SignalManager.Instance.EmitSignal("ToolSelected", (int)DataType.ToolType.Hoe);
    }

    private void OnToolWateringCanButtonPressed()
    {
        SignalManager.Instance.EmitSignal("ToolSelected", (int)DataType.ToolType.WateringCan);
    }

    private void OnToolCornSeedButtonPressed()
    {
        SignalManager.Instance.EmitSignal("ToolSelected", (int)DataType.ToolType.PlantCornSeed);
    }

    private void OnToolTomatoSeedButtonPressed()
    {
        SignalManager.Instance.EmitSignal("ToolSelected", (int)DataType.ToolType.PlantTomatoSeed);
    }

    private void OnToolDeselected()
    {
        this.ToolAxeButton.ReleaseFocus();
        this.ToolHoeButton.ReleaseFocus();
        this.ToolWateringCanButton.ReleaseFocus();
        this.ToolCornSeedButton.ReleaseFocus();
        this.ToolTomatoSeedButton.ReleaseFocus();
    }
}
