using Sandbox.Libs.Sandwind.Models;

namespace Sandbox.Libs.Sandwind;

[GameResource( "Sandwind Config", FileExtension, "A sandwind config file", Icon = "ballot" )]
public class SandwindConfigFile : GameResource
{
    public const string FileExtension = "swc";

    public SandwindConfig RootObject { get; set; }

    protected override void PostLoad()
    {
        PostReload();
    }

    protected override void PostReload()
    {
        // Scene ??= PrefabScene.Create( this );
    }
}