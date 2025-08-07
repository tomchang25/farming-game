using Godot;
using System;

public partial class IdleNPCState : NPCState
{
    [Export] public float MaxDuration { get; set; } = 4.0f;
    [Export] public float MinDuration { get; set; } = 1.0f;

    public override int StateType => (int)NPCStateType.Idle;
    private Timer timer;

    public override void _Ready()
    {
        base._Ready();
        this.timer = new Timer
        {
            OneShot = false,
            Autostart = false,
        };

        this.AddChild(this.timer);
    }
    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnNextTransition()
    {

    }
    public override void OnEnter()
    {
        // GD.Print("IdleNPCState OnEnter");
        this.NPCNode.SetSpeed(NPCStateType.Idle);
        this.NPCNode.UpdateAnimation(NPCStateType.Idle);

        Random random = new Random();
        this.timer.Start(this.MinDuration + (random.NextSingle() * (this.MaxDuration - this.MinDuration)));
        this.timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
    }
    public override void OnExit()
    {
        this.timer.Stop();
        this.timer.Disconnect("timeout", new Callable(this, nameof(OnTimerTimeout)));
    }

    public void OnTimerTimeout()
    {
        this.EmitSignal("StateTransitioned", this, (int)NPCStateType.Walk);
    }


}
