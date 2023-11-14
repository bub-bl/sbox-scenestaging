using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Libs.Sandwind;
using Sandbox.Libs.Sandwind.Components;
using Sandbox.Libs.Sandwind.Generators;
using FileSystem = Sandbox.FileSystem;

public static class Sandwind
{
    // [Event("game.loaded")]
    [Event("scene.play")]
    public static async Task OnPlay()
    {
        var exists = TryGetSandwindComponent(out var component);

        if (!exists)
        {
            Log.Error($"Unable to get {nameof(SandwindComponent).ToTitleCase()} component.");
            // return;
        }

        var config = component.Configuration;
        var outputPath = Path.Combine(LocalProject.CurrentGame.GetRootPath(), config.OutputPath);
        var outputDir = Path.GetDirectoryName(outputPath);

        var types = EditorTypeLibrary.GetTypes<ScssClassGeneratorBase>()
            .Where(x => x is { IsAbstract: false, IsInterface: false })
            .ToList();

        var cssFileBuilder = new StringBuilder();

        Log.Warning($"Generate classes for {types.Count} types..");

        foreach (var type in types)
        {
            var obj = EditorTypeLibrary.Create<ScssClassGeneratorBase>(type.TargetType, Array.Empty<object>());
            var classes = GenerateClasses(config, obj);
            
            cssFileBuilder.Append(classes);
        }

        Directory.CreateDirectory(outputDir);
        await File.WriteAllTextAsync(outputPath, cssFileBuilder.ToString());
    }

    private static StringBuilder GenerateClasses(SandwindConfigFile configFile, ScssClassGeneratorBase classGenerator)
    {
        var cssClasses = classGenerator.Build(configFile);
        var cssBuilder = new StringBuilder();

        foreach (var builder in cssClasses)
        {
            var content = builder.Build();
            cssBuilder.AppendLine(content);
        }

        return cssBuilder;
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