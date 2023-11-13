using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.Libs.Sandwind.CssHelpers.Helpers;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind;

[GameResource("Sandwind Config", FileExtension, "A sandwind config file", Icon = "ballot", Category = "Sandwind")]
public class SandwindConfigFile : GameResource
{
    public const string FileExtension = "swcfg";

    public string ClassPrefix { get; set; } = "sw";
    public string OutputPath { get; set; } = "code/css/app.css";
    public bool AutoCompile { get; set; } = true;
}

[GameResource("Sandwind Class", FileExtension, "A sandwind class file", Icon = "home", Category = "Sandwind")]
public class SandwindClassFile : GameResource
{
    public const string FileExtension = "swc";

    public string ClassName { get; set; }
    public PseudoClass PseudoClass { get; set; } = PseudoClass.None;
    public List<ClassProperty> Properties { get; set; }
}

[GameResource("Sandwind Property", FileExtension, "A sandwind property file", Icon = "edit_note",
    IconBgColor = "#6584eb", IconFgColor = "#FFFFFF", Category = "Sandwind")]
public class SandwindPropertyFile : GameResource
{
    public const string FileExtension = "swp";

    [Category("Enculer")]
    [Description("Property name")]
    public CssProperties Name { get; set; }

    [Category("Enculer")]
    [Description("Property value")]
    public string Value { get; set; }

    [Category("Enculer")]
    [Description("Property value")]
    [ResourceType("swgen")]
    public GameResource ValueGenerator { get; set; }
}

public class ClassProperty
{
    public CssProperties PropertyName { get; set; }
    public string PropertyValue { get; set; }
}

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

[GameResource("Sandwind Generator", "swgen", "A sandwind property file", Icon = "edit_note",
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