using Godot;
using System;
public enum PlayerStateType
{
    Idle,
    Walk,
    Run,
    Chopping,
    Tilling,
    Watering
}
public abstract partial class PlayerState : NodeState
{
    protected Player PlayerNode { get; set; }

    public override void _Ready()
    {
        Node owner = this.Owner;
        if (owner is not Player)
        {
            GD.PushError("PlayerState, Owner is not a Player");
            return;
        }

        this.PlayerNode = owner as Player;
    }
    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnNextTransition() { }
    public override void OnEnter() { }
    public override void OnExit() { }

}
