using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.Libs.Sandwind.CssHelpers.Helpers;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind;

[GameResource("Sandwind Config", FileExtension, "A sandwind config", Icon = "ballot", Category = "Sandwind")]
public class SandwindConfigFile : GameResource
{
    public const string FileExtension = "swcfg";

    public string ClassPrefix { get; set; } = "sw";
    public string OutputPath { get; set; } = "code/css/app.css";
    public bool AutoCompile { get; set; } = true;
    public ClassList Classes { get; set; }
    
    public struct ClassList
    {
        public List<SandwindClassFile> List { get; set; }
    }
}

[GameResource("Sandwind Class", FileExtension, "A sandwind class", Icon = "home", Category = "Sandwind")]
public class SandwindClassFile : GameResource
{
    public const string FileExtension = "swc";

    public string ClassName { get; set; }
    public PseudoClass PseudoClass { get; set; } = PseudoClass.None;
    public GeneratorSettings Generator { get; set; }
    public Properties Properties { get; set; }
    // [ResourceType("swgen")] public ClassGenerator Generator { get; set; }

    public struct GeneratorSettings
    {
        [Range(1, 100, 1)] public int StepCount { get; set; }
        [Range(1, 100, 1)] public int StepValue { get; set; }

        // public CssUnits UnitsType { get; set; }
        public ValueActionType ValueActionType { get; set; }
    }
}

public enum GeneratorType
{
    Int,
    Color
}

public struct Properties
{
    public struct Property
    {
        public CssProperties Name { get; set; }
        public string Value { get; set; }
        public GeneratorSettings2 GeneratorSettings { get; set; }

        // [ResourceType("swgen")] public Generator Generator { get; set; }
    }

    public struct GeneratorSettings2
    {
        public GeneratorType GeneratorType { get; set; }
        public CssUnits UnitsType { get; set; }
        public string Expression { get; set; }
    }

    public List<Property> List { get; set; }
}

// [GameResource("Sandwind Property", FileExtension, "A sandwind property", Icon = "edit_note",
//     IconBgColor = "#6584eb", IconFgColor = "#FFFFFF", Category = "Sandwind")]
// public class SandwindPropertyFile : GameResource
// {
//     public const string FileExtension = "swp";
//
//     [Category("Enculer")]
//     [Description("Property name")]
//     public CssProperties Name { get; set; }
//
//     [Category("Enculer")]
//     [Description("Property value")]
//     public string Value { get; set; }
//
//     public bool IsTest { get; set; }
//
//     [Category("Enculer"), HideIf(nameof(IsTest), true)]
//     [Description("Property value")]
//     [ResourceType("swgen")]
//     public GameResource ValueGenerator { get; set; }
// }

public enum CssUnits
{
    Pixel,
    Rem,
    Em,
    Rad,
    Percentage
}

public enum ValueActionType
{
    Add,
    Multiply
}

public abstract class ClassGenerator : GameResource
{
    public abstract IEnumerable<CssClassBuilder> Build(SandwindClassFile classFile);
}

[GameResource("Sandwind Generator", "swgen", "A sandwind generator", Icon = "edit_note",
    Category = "Sandwind")]
public sealed class IntValueGeneratorResource : ClassGenerator
{
    [Range(1, 100, 1)] public int StepCount { get; set; }
    [Range(1, 100, 1)] public int StepValue { get; set; }

    public CssUnits UnitsType { get; set; } = CssUnits.Pixel;
    public ValueActionType ValueActionType { get; set; } = ValueActionType.Add;

    public override IEnumerable<CssClassBuilder> Build(SandwindClassFile classFile)
    {
        for (var i = 0; i < StepCount; i++)
        {
            var width = i * StepValue;
            
            var classBuilder = new CssClassBuilder()
                .WithClassName($"{classFile.ClassName}-{width}[px]")
                .WithProperty(StyleProperties.Width, $"{width}px");

            yield return classBuilder;
        }
    }
}

public static class ExpressionCompiler
{
    public static int CompileMultiplyExpression(int a, int b)
    {
        // Définir les paramètres de l'expression
        var i = Expression.Parameter(typeof(int), "i");
        var stepValue = Expression.Parameter(typeof(int), "StepValue");

        // Créer l'expression i * StepValue
        var multiplyExpression = Expression.Multiply(i, stepValue);

        // Créer une lambda expression avec le corps de la fonction
        var lambdaExpression = Expression.Lambda<Func<int, int, int>>(multiplyExpression, i, stepValue);

        // Compiler l'expression lambda en une fonction
        var multiplyFunction = lambdaExpression.Compile();

        // Tester la fonction compilée
        var result = multiplyFunction(a, b);

        // Console.WriteLine(result); // Affiche 50
        return result;
    }
}