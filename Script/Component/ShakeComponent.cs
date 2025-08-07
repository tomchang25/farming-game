using Godot;
using System;

public partial class ShakeComponent : Node
{
    [Export]
    public Node2D ShakeNode { get; set; }

    private Timer shakeTimer;

    public override void _Ready()
    {
        if (this.ShakeNode == null)
        {
            GD.PushError("ShakeNode not found");
            return;
        }

        this.shakeTimer = new Timer
        {
            Autostart = false,
            OneShot = true
        };
        this.AddChild(this.shakeTimer);
        this.shakeTimer.Connect("timeout", new Callable(this, nameof(OnShakeTimerTimeout)));
    }

    public void Shake(float duration, float intensity)
    {
        // Guard clause to prevent a new shake if the timer is already running
        // if (!this.shakeTimer.IsStopped())
        // {
        //     return;
        // }

        if (this.ShakeNode.Material == null)
        {
            GD.PushError("Material not found");
            return;
        }

        this.ShakeNode.Material.Set("shader_parameter/shake_intensity", intensity);

        // Start the timer for the specified duration
        this.shakeTimer.WaitTime = duration;
        this.shakeTimer.Start();
    }

    private void OnShakeTimerTimeout()
    {
        // Reset the shake intensity when the timer finishes
        this.ShakeNode.Material.Set("shader_parameter/shake_intensity", 0);
    }
}
