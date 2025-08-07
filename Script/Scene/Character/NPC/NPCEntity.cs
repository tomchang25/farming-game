using Godot;
using System;

public partial class NPCEntity : CharacterBody2D
{
    [Export] public float MaxWalkSpeed { get; set; } = 100;
    [Export] public float MinWalkSpeed { get; set; } = 50;


    private float speed;
    private AnimatedSprite2D sprite;
    private NavigationAgent2D agent;
    private Vector2 targetPosition;

    private bool currentIsMoving;

    public override void _Ready()
    {
        this.sprite = this.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        this.agent = this.GetNode<NavigationAgent2D>("NavigationAgent2D");
        this.agent.Connect("velocity_computed", new Callable(this, nameof(OnNavigationAgent2dVelocityComputed)));
    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (this.agent.IsNavigationFinished())
        {
            this.currentIsMoving = false;
        }

        Vector2 nextPosition = this.agent.GetNextPathPosition();
        Vector2 direction = (nextPosition - this.GlobalPosition).Normalized();

        Vector2 velocity = direction * this.speed;


        if (this.agent.AvoidanceEnabled)
        {
            this.agent.Velocity = velocity;
        }
        else
        {
            this.Velocity = velocity;
            this.MoveAndSlide();
            this.UpdateFlip();
        }
    }
    public void OnNavigationAgent2dVelocityComputed(Vector2 safeVelocity)
    {
        this.Velocity = safeVelocity;
        this.MoveAndSlide();
        this.UpdateFlip();

    }

    public void SetSpeed(Enum stateType)
    {
        Random random = new Random();
        switch (stateType)
        {
            case NPCStateType.Idle:
                this.speed = 0;
                break;
            case NPCStateType.Walk:
                this.speed = this.MinWalkSpeed + (random.NextSingle() * (this.MaxWalkSpeed - this.MinWalkSpeed));
                break;
            default:
                break;
        }
    }

    public void UpdateTargetPosition()
    {
        this.targetPosition = NavigationServer2D.MapGetRandomPoint(this.agent.GetNavigationMap(), this.agent.NavigationLayers, false);
        this.agent.TargetPosition = this.targetPosition;

        this.currentIsMoving = true;
    }

    public void UpdateAnimation(Enum stateType)
    {
        switch (stateType)
        {
            case NPCStateType.Idle:
                this.sprite.Play("Idle");
                break;
            case NPCStateType.Walk:
                this.sprite.Play("Move");
                break;
            default:
                break;
        }
    }

    public bool IsMoving()
    {
        return this.currentIsMoving;
    }

    private void UpdateFlip()
    {
        if (this.Velocity.X == 0)
        {
            return;
        }

        this.sprite.FlipH = this.Velocity.X < 0;
    }
}
