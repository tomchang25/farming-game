using Godot;
using System;

public partial class Door : StaticBody2D
{
    private InteractableComponent interactableComponent;
    private AnimationPlayer animationPlayer;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        this.interactableComponent = this.GetNode<InteractableComponent>("InteractableComponent");

        this.interactableComponent.Connect("InteractableActivated", new Callable(this, nameof(OnInteractableActivated)));
        this.interactableComponent.Connect("InteractableDeactivated", new Callable(this, nameof(OnInteractableDeactivated)));

        this.animationPlayer = this.GetNode<AnimationPlayer>("AnimationPlayer");

        this.animationPlayer.Connect("animation_finished", new Callable(this, nameof(OnAnimationFinished)));
    }

    private void OnInteractableActivated()
    {
        this.animationPlayer.Play("OpenDoor");
    }

    private void OnInteractableDeactivated()
    {
        this.animationPlayer.Play("CloseDoor");
        this.SetCollisionLayerValue(3, true);
    }

    private void OnAnimationFinished(string animationName)
    {
        if (animationName == "OpenDoor")
        {
            this.SetCollisionLayerValue(3, false);
        }
    }
}
