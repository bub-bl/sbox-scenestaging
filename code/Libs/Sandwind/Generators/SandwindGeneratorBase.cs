using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class SandwindGeneratorBase
{
    protected virtual PseudoClass PseudoClass { get; }
    protected abstract string ClassName { get; }

    protected abstract Func<object[], List<(CssProperty, object)>> Properties { get; }

    protected static readonly Dictionary<string, object> Sizes = new()
    {
        { "none", 0 },
        { "sm", 2 },
        { "", 4 },
        { "md", 6 },
        { "lg", 8 },
        { "xl", 12 },
        { "2xl", 16 },
        { "3xl", 24 },
        { "full", 9999 },
    };

    protected static readonly Dictionary<string, object> Justify = new()
    {
        { "center", "center" },
        { "end", "flex-end" },
        { "start", "flex-start" },
        { "between", "space-between" },
        { "around", "space-around" },
        { "evenly", "space-evenly" },
    };

    protected static readonly Dictionary<string, object> Align = new()
    {
        { "auto", "auto" },
        { "center", "center" },
        { "stretch", "stretch" },
        { "baseline", "baseline" },
        { "end", "flex-end" },
        { "start", "flex-start" },
        { "between", "space-between" },
        { "around", "space-around" },
    };
    
    protected static readonly Dictionary<string, object> BackgroundRepeat = new()
    {
        { "no-repeat", "no-repeat" },
        { "repeat", "repeat" },
        { "repeat-x", "repeat-x" },
        { "repeat-y", "repeat-y" },
    };
    
    protected static readonly Dictionary<string, object> BackgroundPosition = new()
    {
        { "center", "center" },
        { "top", "top" },
        { "bottom", "bottom" },
        { "left", "left" },
        { "left-top", "left top" },
        { "left-bottom", "left bottom" },
        { "right", "right" },
        { "right-top", "right top" },
        { "right-bottom", "right bottom" },
    };
    
    // protected static readonly Dictionary<string, object> BackgroundSize = new()
    // {
    //     { "auto", "auto" },
    //     { "cover", "cover" },
    //     { "contain", "contain" },
    // };

    protected IEnumerable<CssClassBuilder> GenerateValues(SandwindConfigFile configFile,
        Dictionary<string, object> values)
    {
        foreach (var value in values)
        {
            var dash = !string.IsNullOrEmpty(value.Key) ? "-" : "";
            var className = $"{ClassName}{dash}{value.Key}";

            var classBuilder = new CssClassBuilder()
                .WithClassName(className)
                .WithPseudoClass(PseudoClass);

            var props = Properties.Invoke(new[] { value.Key, value.Value });

            foreach (var prop in props)
                classBuilder.WithProperty(prop.Item1, prop.Item2.ToString());

            yield return classBuilder;
        }
    }

    protected IEnumerable<CssClassBuilder> GenerateIncrementals(SandwindConfigFile configFile, int startIndex,
        int steps, float stepInterval, float valueInterval)
    {
        return Enumerable.Range(startIndex + 1, steps).Select(i =>
        {
            var valueName = i * stepInterval;
            var className = $"{ClassName}-{valueName}";
            var value = i * valueInterval;

            var classBuilder = new CssClassBuilder()
                .WithClassName(className)
                .WithPseudoClass(PseudoClass);

            var props = Properties.Invoke(new object[] { i, steps, value });

            foreach (var prop in props)
                classBuilder.WithProperty(prop.Item1, $"{prop.Item2}px");

            return classBuilder;
        });
    }

    protected IEnumerable<CssClassBuilder> GenerateFractionals(SandwindConfigFile configFile, int max)
    {
        return Enumerable.Range(1, max - 1).Select(i =>
        {
            var className = $"{ClassName}-{i}/{max}";
            var value = (float)i / max * 100F;

            var classBuilder = new CssClassBuilder()
                .WithClassName(className)
                .WithPseudoClass(PseudoClass);

            var props = Properties.Invoke(new object[] { i, max - 1, value });

            foreach (var prop in props)
                classBuilder.WithProperty(prop.Item1, $"{prop.Item2}%");

            return classBuilder;
        });
    }

    protected IEnumerable<CssClassBuilder> GenerateHslColor(SandwindConfigFile configFile, string colorName, float hue,
        float saturate = 50f)
    {
        const int lightnessStep = 10;

        for (var lightness = 100 - lightnessStep; lightness > 0; lightness -= lightnessStep)
        {
            var className = $"{ClassName}-{colorName}-{lightness * 10f}";

            var classBuilder = new CssClassBuilder()
                .WithClassName(className)
                .WithPseudoClass(PseudoClass);

            var props = Properties.Invoke(new object[] { hue, saturate, (float)lightness });

            foreach (var prop in props)
                classBuilder.WithProperty(prop.Item1, $"hsl({hue}, {saturate}%, {prop.Item2}%)");

            yield return classBuilder;
        }
    }

    public abstract IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile);
}