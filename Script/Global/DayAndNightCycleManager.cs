using Godot;
using System;

public partial class DayAndNightCycleManager : Node
{
    [Signal] public delegate void TimeTickedEventHandler(float timeTick);
    [Signal] public delegate void TimeChangedEventHandler(int day, int hour, int minute);
    [Signal] public delegate void DayChangedEventHandler(int day);

    public static DayAndNightCycleManager Instance { get; set; }
    public int CurrentDay { get; set; } = 1;
    public int CurrentHour { get; set; }
    public int CurrentMinute { get; set; }

    public float GameSpeed { get; set; } = 1f;

    private const int MINUTE_TO_HOUR = 60;
    private const int HOUR_TO_DAY = 24;
    private const float GAME_MINUTE_DURATION = (float)Math.Tau / (MINUTE_TO_HOUR * HOUR_TO_DAY);

    private float timeTick;

    public override void _Ready()
    {
        base._Ready();

        Instance = this;

        // this.timeTick = 0f;
        // this.timeTick += this.CurrentDay * HOUR_TO_DAY * MINUTE_TO_HOUR * GAME_MINUTE_DURATION;
        // this.timeTick += this.CurrentHour * MINUTE_TO_HOUR * GAME_MINUTE_DURATION;
        // this.timeTick += this.CurrentMinute * GAME_MINUTE_DURATION;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        this.timeTick += (float)delta * this.GameSpeed * GAME_MINUTE_DURATION;
        this.EmitSignal("TimeTicked", this.timeTick);
        this.RecalculateTime();
    }

    public void SetSpeed(float speed)
    {
        this.GameSpeed = speed;
    }

    private void RecalculateTime()
    {
        int day = (int)(this.timeTick / (HOUR_TO_DAY * MINUTE_TO_HOUR * GAME_MINUTE_DURATION));
        int hour = (int)(this.timeTick / (MINUTE_TO_HOUR * GAME_MINUTE_DURATION) % HOUR_TO_DAY);
        int minute = (int)(this.timeTick / GAME_MINUTE_DURATION % MINUTE_TO_HOUR);

        if (day != this.CurrentDay)
        {
            this.EmitSignal("DayChanged", day);
        }

        if (minute != this.CurrentMinute)
        {
            this.EmitSignal("TimeChanged", day, hour, minute);
        }

        this.CurrentDay = day;
        this.CurrentHour = hour;
        this.CurrentMinute = minute;
    }
}
