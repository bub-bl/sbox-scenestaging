using Sandbox;

public sealed class EntitySpawner : BaseComponent
{
    [Property] public float SpawnDist { get; set; } = 8f;
    [Property] public Vector3 SpawnDirection { get; set; }
    [Property] public GameObject EntityModel { get; set; }

    public override void OnStart()
    {
        var currentPos = Transform.Position;
        
        SceneUtility.
        var obj = SceneUtility.Instantiate( EntityModel, currentPos + SpawnDirection * SpawnDist, Rotation.Identity );
        // GameObject.Children.Add(obj);
        obj.SetParent(GameObject);
    }
}