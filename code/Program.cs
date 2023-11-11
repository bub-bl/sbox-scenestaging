global using System.Linq;
global using System;
using Sandbox;


public static class Program
{
	public static void Main()
	{
		//
		// In the future this won't exist, we'll have an option for "default scene"
		// and when you press play it'll load that.
		//

		GameManager.ActiveScene = new Scene();
		GameManager.ActiveScene.LoadFromFile( "scenes/tests/menu.scene" );

		GameManager.IsPlaying = true;
	}
}

public class TestComponentBase : BaseComponent
{
	[Property] public int Age { get; set; }
}

public class AppleComponent : TestComponentBase
{
	[Property] public string Name { get; set; }
}

public class MyComponent : BaseComponent
{
	[Property] public TestComponentBase Component { get; set; }
}