using Godot;
using Godot.Collections;
using System;

public partial class InventoryPanel : PanelContainer
{
    private Node inventoryItemGroup;
    public override void _Ready()
    {
        base._Ready();
        SignalManager.Instance.Connect(nameof(SignalManager.InventoryChanged), new Callable(this, nameof(UpdateInventory)));

        this.inventoryItemGroup = this.GetNode("MarginContainer/VBoxContainer");
    }

    public void UpdateInventory(Dictionary inventory)
    {
        foreach (Node item in this.inventoryItemGroup.GetChildren())
        {
            if (inventory.ContainsKey(item.Name))
            {
                Label label = item.GetNode<Label>("Label");
                label.Text = inventory[item.Name].ToString();
            }
        }
    }
}
