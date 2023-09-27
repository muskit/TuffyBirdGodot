using Godot;

public partial class PipeSpawner : Node2D
{
    [Export]
    public PackedScene pipe;
    public Timer spawnTimer;

    public float spawnTime = 2f;
    public float bottomRange = -220f;
    public float topRange = 220f;
    // Start is called before the first frame update
    public override void _Ready()
    {
        // InvokeRepeating("SpawnPipe", 0f, spawnTime);
        spawnTimer = new Timer();
        AddChild(spawnTimer);
        spawnTimer.Timeout += SpawnPipe;
        spawnTimer.WaitTime = spawnTime;
        spawnTimer.OneShot = false;
        spawnTimer.Start();
    }

    void SpawnPipe(){
        // Instantiate(pipes, new Vector3(15, Random.Range(bottomRange, topRange),0), Quaternion.identity);
        
        var p = pipe.Instantiate<Node2D>();
        var vertPos = (float) GD.RandRange(bottomRange, topRange);
        p.Position = new Vector2(15, vertPos);
        AddChild(p);
    }
}
