using Godot;

public partial class Pipe : Node2D
{
    public float speed = 10f;
    public float xPosToDestroy = -30f;

    // Update is called once per frame
    public override void _Process(double delta)
    {
        this.Position += new Vector2(-speed, 0) * (float) delta;
        if(this.Position.X <= xPosToDestroy){
            // Destroy(gameObject);
            QueueFree();
        }
    }
}
