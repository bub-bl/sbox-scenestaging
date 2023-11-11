namespace Sandbox.Libs.Sandwind.Components;

public class SandwindComponent : BaseComponent, BaseComponent.ExecuteInEditor
{
    [Property] public string Prefix { get; set; } = "sw";
    [Property] public string OutputPath { get; set; } = "/code/app.css";
    [Property] public bool AutoCompile { get; set; } = true;

    public override void OnStart()
    {
        
    }
}