using Godot;

public partial class PipeSpawner : Node2D
{
    [Export]
    public PackedScene pipe;
    public float spawnTime = 2f;
    public float bottomRange = -4f;
    public float topRange = 6f;
    // Start is called before the first frame update
    void Start()
    {
        // load Pipe scene that we instantiate
        // pipe = GD.Load<PackedScene>("res://Things/Pipe.tscn");
        
        // InvokeRepeating("SpawnPipe", 0f, spawnTime);
        var t = new Timer();
        AddChild(t);
        t.Timeout += SpawnPipe;
        t.WaitTime = spawnTime;
        t.OneShot = false;
        t.Start();
    }

    void SpawnPipe(){
        // Instantiate(pipes, new Vector3(15, Random.Range(bottomRange, topRange),0), Quaternion.identity);
        
        var p = pipe.Instantiate<Node2D>();
        var vertPos = (float) GD.RandRange(bottomRange, topRange);
        p.Position = new Vector2(15, vertPos);
        AddChild(p);
    }
}
