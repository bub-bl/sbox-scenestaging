using System.Collections.Generic;
using System.IO;
using Sandbox.Libs.Sandwind.Attributes;
using Sandbox.Libs.Sandwind.Components;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.Libs.Sandwind.CssHelpers.Helpers;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind;

[PseudoClass(PseudoClass.Focus | PseudoClass.Hover)]
public class WidthCssClass : ClassGeneratorBase
{
    public override string ClassName => "w";

    public override List<CssClassBuilder> Build()
    {
        const int steps = 10;
        const int pixels = 4;

        var classes = new List<CssClassBuilder>();

        for (var i = 0; i < steps; i++)
        {
            var width = i * pixels;

            var classBuilder = new CssClassBuilder()
                .WithClassName($"{ClassName}-{width}")
                .WithProperty(StyleProperties.Width, $"{width}px");

            classes.Add(classBuilder);
        }

        return classes;
    }
}

public class ClassContext
{
    public string ClassName { get; set; }
}

// public static class Sandwind
// {
//     private static readonly List<ClassGenerator> _generators = new();
//
//     [Event("game.loaded")]
//     public static async void GameStarted(Package package)
//     {
//         var path = Path.Combine(LocalProject.CurrentGame.GetRootPath(), "configs", "sandwind_config.swc");
//         Log.Warning("Path: " + path);
//
//         var exists = ResourceLibrary.TryGet<SandwindConfigFile>(path, out var resource);
//
//         if (!exists)
//         {
//             Log.Error($"Unable to find {nameof(SandwindConfigFile)}.");
//             return;
//         }
//
//         var comp = TryGetSandwindComponent(out var component);
//
//         if (comp is false)
//         {
//             Log.Error($"Unable to get {nameof(SandwindComponent)} component.");
//             return;
//         }
//
//         var cssFilePath = component.OutputPath;
//         Log.Warning("CssFilePath: " + cssFilePath);
//     }
//
//     private static bool TryGetSandwindComponentParent(out GameObject gameObject)
//     {
//         var children = global::GameManager.ActiveScene.Children;
//         var gameObjects = children.Where(x => x.GetComponent<SandwindComponent>() is not null).ToList();
//
//         if (gameObjects.Count > 1)
//         {
//             Log.Error($"Only one {nameof(SandwindComponent)} is allowed per scene.");
//
//             gameObject = default;
//             return false;
//         }
//
//         gameObject = gameObjects.FirstOrDefault();
//         return gameObject is not null;
//     }
//
//     private static bool TryGetSandwindComponent(out SandwindComponent component)
//     {
//         var go = TryGetSandwindComponentParent(out var gameObject);
//         
//         if (!go)
//         {
//             component = default;
//             return false;
//         }
//         
//         component = gameObject.GetComponent<SandwindComponent>();
//         return component is not null;
//     }
//
//     public static void LoadConfigurationFile()
//     {
//     }
//
//     public static void GenerateCssFile()
//     {
//     }
//
//     public static void GenerateClass()
//     {
//     }
// }