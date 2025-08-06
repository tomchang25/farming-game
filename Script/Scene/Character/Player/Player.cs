using Godot;
using System;

public partial class Player : CharacterBody2D
{
    // private AnimatedSprite2D playerSprite;
    // private Sprite2D playerSprite;
    [Export]
    public DataType.ToolType CurrentTool { get; set; }
    public StringName CurrentAnimation => this.animationStateMachinePlayback.GetCurrentNode();

    private AnimationTree animationTree;
    private AnimationNodeStateMachinePlayback animationStateMachinePlayback;

    private Vector2 playerDirection = Vector2.Down;


    private float playerSpeed;
    private const float PLAYER_WALK_SPEED = 100;
    private const float PLAYER_RUN_SPEED = 200;


    public override void _Ready()
    {
        this.animationTree = this.GetNode<AnimationTree>("AnimationTree");
        this.animationStateMachinePlayback = (AnimationNodeStateMachinePlayback)this.animationTree.Get("parameters/AnimationNodeStateMachine/playback");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        this.Velocity = this.playerDirection * this.playerSpeed;
        this.MoveAndSlide();

    }
    public void UpdateDirection(Vector2 direction)
    {
        this.playerDirection = direction;
        this.animationTree.Set("parameters/AnimationNodeStateMachine/Idle/blend_position", direction);
        this.animationTree.Set("parameters/AnimationNodeStateMachine/Move/blend_position", direction);
        this.animationTree.Set("parameters/AnimationNodeStateMachine/Chopping/blend_position", direction);
        this.animationTree.Set("parameters/AnimationNodeStateMachine/Tilling/blend_position", direction);
        this.animationTree.Set("parameters/AnimationNodeStateMachine/Watering/blend_position", direction);
    }

    public void SetSpeed(PlayerStateType playerStateType)
    {
        switch (playerStateType)
        {
            case PlayerStateType.Idle:
                this.playerSpeed = 0;
                break;
            case PlayerStateType.Walk:
                this.playerSpeed = PLAYER_WALK_SPEED;
                break;
            case PlayerStateType.Run:
                this.playerSpeed = PLAYER_RUN_SPEED;
                break;
            case PlayerStateType.Chopping:
            case PlayerStateType.Tilling:
            case PlayerStateType.Watering:
                this.playerSpeed = 0;
                break;
            default:
                break;
        }
    }

    public void UpdateAnimation(PlayerStateType playerStateType)
    {
        switch (playerStateType)
        {
            case PlayerStateType.Idle:
                this.animationStateMachinePlayback.Start("Idle");
                break;
            case PlayerStateType.Walk:
                this.animationStateMachinePlayback.Travel("Move");
                this.animationTree.Set("parameters/TimeScale/scale", 1.0f);
                break;
            case PlayerStateType.Run:
                this.animationStateMachinePlayback.Travel("Move");
                this.animationTree.Set("parameters/TimeScale/scale", 10.0f);
                break;
            case PlayerStateType.Chopping:
                this.animationStateMachinePlayback.Travel("Chopping");
                break;
            case PlayerStateType.Tilling:
                this.animationStateMachinePlayback.Travel("Tilling");
                break;
            case PlayerStateType.Watering:
                this.animationStateMachinePlayback.Travel("Watering");
                break;
            default:
                break;
        }
    }

}
