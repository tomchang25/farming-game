using Godot;
using System;
public enum NPCStateType
{
    Idle,
    Walk,
}
public abstract partial class NPCState : NodeState
{
    protected NPCEntity NPCNode { get; set; }

    public override void _Ready()
    {
        Node owner = this.Owner;
        if (owner is not NPCEntity)
        {
            GD.PushError("NPCState, Owner is not a NPCEntity");
            return;
        }

        this.NPCNode = owner as NPCEntity;
    }
    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnNextTransition() { }
    public override void OnEnter() { }
    public override void OnExit() { }

}
