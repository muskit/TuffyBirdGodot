using System.Net;
using Godot;

public partial class Pipe : Node2D
{
    [Export]
    private Area2D scoringGap;
    public float speed = 240f;
    public float xPosToDestroy = -1600f;

    public override void _Ready()
    {
        // BodyEntered is an event.
        // Whenever this event gets triggered, it will call the method OnBodyEntered, which is defined down below past _Process.
        scoringGap.BodyEntered += OnBodyEntered;
    }

    public override void _Process(double delta)
    {
        this.Position += new Vector2(-speed, 0) * (float) delta;
        if(this.Position.X <= xPosToDestroy){
            // Destroy(gameObject);
            QueueFree();
        }
    }

    private void OnBodyEntered(Node2D _other)
    {
        var player = _other as Player;
        if (player == null) return;

        player.AddScore();
    }
}
