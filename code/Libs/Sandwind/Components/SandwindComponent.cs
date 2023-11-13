namespace Sandbox.Libs.Sandwind.Components;

public class SandwindComponent : BaseComponent, BaseComponent.ExecuteInEditor
{
    [Property] public SandwindConfigFile Configuration { get; set; }
    
    public override void OnStart()
    {
        
    }
}

internal static class SandwindGenerator
{
    public static void GenerateCss()
    {
        
    }
}