using Godot;
using System;

public partial class DayAndNightPanel : Control
{
    private Label dayLabel;
    private Label timeLabel;

    private Button normalSpeedButton;
    private Button fastSpeedButton;
    private Button superFastSpeedButton;

    public override void _Ready()
    {
        this.dayLabel = this.GetNode<Label>("VBoxContainer/DayPanel/MarginContainer/DayLabel");
        this.timeLabel = this.GetNode<Label>("VBoxContainer/TimePanel/MarginContainer/TimeLabel");

        DayAndNightCycleManager.Instance.DayChanged += this.OnDayChanged;
        DayAndNightCycleManager.Instance.TimeChanged += this.OnTimeChanged;

        this.normalSpeedButton = this.GetNode<Button>("VBoxContainer/HBoxContainer/NormalSpeedButton");
        this.fastSpeedButton = this.GetNode<Button>("VBoxContainer/HBoxContainer/FastSpeedButton");
        this.superFastSpeedButton = this.GetNode<Button>("VBoxContainer/HBoxContainer/SuperFastSpeedButton");

        this.normalSpeedButton.Pressed += () => DayAndNightCycleManager.Instance.SetSpeed(1);
        this.fastSpeedButton.Pressed += () => DayAndNightCycleManager.Instance.SetSpeed(100);
        this.superFastSpeedButton.Pressed += () => DayAndNightCycleManager.Instance.SetSpeed(1000);

        // this.normalSpeedButton.GrabFocus();
    }

    public void OnDayChanged(int day)
    {
        this.dayLabel.Text = "Day " + day.ToString("D2");
    }

    public void OnTimeChanged(int day, int hour, int minute)
    {
        this.timeLabel.Text = hour.ToString("D2") + ":" + minute.ToString("D2");
    }


}
