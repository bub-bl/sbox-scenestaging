
using Sandbox;

internal class SurfScene : BaseComponent
{

	public override void OnEnabled()
	{
		base.OnEnabled();

		Game.TickRate = 64; // this would be good
	}

}
