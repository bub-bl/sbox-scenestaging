using Sandbox;

public sealed class MobMovement : BaseComponent
{
	private Vector3 _castelDir;
	
	[Property] public float Speed { get; set; } = 1f;

	public override void OnStart()
	{
		var entSpawner = GameObject.GetComponentInParent<EntitySpawner>();
		_castelDir = entSpawner.SpawnDirection;
	}

	public override void Update()
	{
		Transform.Position += _castelDir * Speed * Time.Delta;
	}
}
