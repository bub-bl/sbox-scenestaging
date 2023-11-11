using System.IO;
using Sandbox.Libs.Sandwind;
using Sandbox.Libs.Sandwind.Components;

namespace Sandbox;

public static class Sandwind
{
    private static readonly List<ClassGenerator> _generators = new();

    [Event("scene.open")]
    public static async void SceneOpen()
    {
        Log.Warning("Scene Open");
    }
    
    [Event("scene.play")]
    public static async void ScenePlay()
    {
        Log.Warning("Scene Play");
    }
    
    [Event("scene.stop")]
    public static async void SceneStop()
    {
        Log.Warning("Scene Stop");
    }
    
    [Event("game.loaded")]
    public static async void GameStarted(Package package)
    {
        var path = Path.Combine(LocalProject.CurrentGame.GetRootPath(), "configs", "sandwind_config.swc");
        Log.Warning("Path: " + path);

        var exists = ResourceLibrary.TryGet<SandwindConfigFile>(path, out var resource);

        if (!exists)
        {
            Log.Error($"Unable to find {nameof(SandwindConfigFile)}.");
            return;
        }

        var comp = TryGetSandwindComponent(out var component);

        if (comp is false)
        {
            Log.Error($"Unable to get {nameof(SandwindComponent)} component.");
            return;
        }

        var cssFilePath = component.OutputPath;
        Log.Warning("CssFilePath: " + cssFilePath);
    }

    private static bool TryGetSandwindComponentParent(out GameObject gameObject)
    {
        var children = global::GameManager.ActiveScene.Children;
        var gameObjects = children.Where(x => x.GetComponent<SandwindComponent>() is not null).ToList();

        if (gameObjects.Count > 1)
        {
            Log.Error($"Only one {nameof(SandwindComponent)} is allowed per scene.");

            gameObject = default;
            return false;
        }

        gameObject = gameObjects.FirstOrDefault();
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

    public static void LoadConfigurationFile()
    {
    }

    public static void GenerateCssFile()
    {
    }

    public static void GenerateClass()
    {
    }
}