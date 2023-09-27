using System;
using Godot;

public partial class Player : RigidBody2D
{
    //NOTE: variables/objects with public in front of them can be changed in the inspector
    //GODOT NOTE: the only way to show variables in the inspector is to add the [Export] attribute on a variable.
    // public/private doesn't matter.

    public static Player player;

    //These are the variables for the 'velocity' and 'isMovable' attributes
    [Export]
    public float jumpVelocity;
    public bool isMovable = true;

    //Declaring our components
    [Export]
    private Sprite2D sprite;
    [Export]
    public AudioScript audioScript;


    //These will store our jumping and falling sprites
    [Export]
    public Texture2D jumping;
    [Export]
    public Texture2D falling;


    // Start is called before the first frame update
    public override void _Ready()
    {
        player = this;
        this.BodyEntered += OnCollisionEnter2D;
    }

    // Update is called once per frame
    public override void _Process(double delta)
    {
        //this checks once per frame if you have pressed the space bar and you can move. If so, the player's rigidbody's velocity
        //  is now equal to Vector2.up (aka new Vector2(0,1)) times your velocity value
        
        // GODOT: input is mapped to an "Action" in the editor; we refer to that action instead of the actual key
        if (Input.IsActionJustPressed("jump") && isMovable)
        {
            audioScript.PlayJumpSound();
            LinearVelocity = Vector2.Up * jumpVelocity;
        }

        //checks if the velocity (on the y axis) is less or greater than zero and changes the sprite accordingly
        if (LinearVelocity.Y > 0)
        {
            sprite.Texture = jumping;
        }else{
            sprite.Texture = falling;
        }
    }

    //checks if the player collided with a pipe (StaticBody2D).
    //if so, play the hit sound that is stored in SoundEffects's AudioScript.cs,
    //then set isMovable to false meaning we can't jump anymore
    private void OnCollisionEnter2D(Object _other)
    {
        GD.Print($"Hit a {_other.GetType()}");
        if (!isMovable) return; // do nothing if we're no longer movable (we've game over'd!)

        var other = _other as StaticBody2D;
        if (other == null) return; // didn't collide with a StaticBody2D (what we've set the pipe's collisions to be)

        var otherName = other.Name.ToString();
        if(otherName.Contains("TopPipe") || otherName.Contains("BtmPipe"))
        {
            GD.Print("Game over!");
            audioScript.PlayHitSound();
            isMovable = false;
            // disable all collisions
            this.CollisionLayer = 0;
            this.CollisionMask = 0;
        }
    }

    // method called by pipe to award a point to the player
    public void AddScore()
    {
        GD.Print("Score!");
        audioScript.PlayScoreSound();
    }
    
    /** GODOT: It's now the pipe's job to score the player, since RigidBody2Ds (player) can't detect Area2Ds. */

    //checks if the player enters the trigger game object and plays a sound if the player is still alive
    // Note the difference in how we get a reference to the "other"'s tag!
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.tag == "Score" && isMovable ){
    //         audioScript.PlayScoreSound();
    //     }
        
    // }
}
