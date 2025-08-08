using Godot;
using System;

public partial class DayNightCycleComponent : CanvasModulate
{
    [Export]
    private GradientTexture2D gradientTexture;
    public override void _Process(double delta)
    {
        base._Process(delta);

        DayAndNightCycleManager.Instance.TimeTicked += this.OnTimeTicked;
    }


    private void OnTimeTicked(float time)
    {
        float sampleValue = (float)(0.5 * (Math.Sin(time - (Math.PI / 2)) + 1.0));
        this.Color = this.gradientTexture.Gradient.Sample(sampleValue);
    }
}
