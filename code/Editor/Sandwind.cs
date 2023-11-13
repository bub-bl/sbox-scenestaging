using Sandbox.Libs.Sandwind;
using Sandbox.Libs.Sandwind.Components;

public static class Sandwind
{
    private static readonly List<ClassGenerator> _generators = new();

    // [Event("scene.open")]
    // public static async void SceneOpen()
    // {
    //     Log.Warning("Scene Open");
    // }
    //
    // [Event("scene.play")]
    // public static async void ScenePlay()
    // {
    //     Log.Warning("Scene Play");
    // }
    //
    // [Event("scene.stop")]
    // public static async void SceneStop()
    // {
    //     Log.Warning("Scene Stop");
    // }

    // [Event("game.loaded")]
    [Event("scene.play")]
    public static void OnPlay()
    {
        var exists = TryGetSandwindComponent(out var component);

        if (!exists)
        {
            Log.Error($"Unable to get {nameof(SandwindComponent).ToTitleCase()} component.");
            return;
        }

        var config = component.Configuration;
        var cssFilePath = config.OutputPath;
    }

    private static bool TryGetSandwindComponentParent(out GameObject gameObject)
    {
        var children = GameManager.ActiveScene.Scene.Children;
        var gameObjects = children.Where(x => x.GetComponent<SandwindComponent>(deep: true) is not null).ToList();

        if (gameObjects.Count > 1)
        {
            Log.Error($"Only one {nameof(SandwindComponent).ToTitleCase()} is allowed per scene.");

            gameObject = default;
            return false;
        }
        
        var comp = gameObjects.Select(x => x.GetComponent<SandwindComponent>(deep: true)).FirstOrDefault();
        gameObject = comp?.GameObject;
        
        return gameObject is not null;
    }

    private static bool TryGetSandwindComponent(out SandwindComponent component)
    {
        var go = TryGetSandwindComponentParent(out var gameObject);
        
        if (!go)
        {
            component = default;
            return false;
        }
        
        component = gameObject.GetComponent<SandwindComponent>();
        return component is not null;
    }
}