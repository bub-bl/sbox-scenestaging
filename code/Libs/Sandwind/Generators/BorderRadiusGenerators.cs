using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class BorderRadiusGeneratorBase : SandwindGeneratorBase
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;
    
    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) =>
        new List<CssClassBuilder>(GenerateValues(configFile, Sizes));
}

public sealed class BorderRadiusGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderRadius, $"{value}px"),
        };
    };
}

public sealed class BorderTopLeftGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded-tl";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopLeft, $"{value}px"),
        };
    };
}

public sealed class BorderBottomLeftGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded-bl";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderBottomLeft, $"{value}px"),
        };
    };
}

public sealed class BorderTopRightGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded-tr";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopRight, $"{value}px"),
        };
    };
}

public sealed class BorderBottomRightGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded-br";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderBottomRight, $"{value}px"),
        };
    };
}

public sealed class BorderTopGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded-t";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopLeft, $"{value}px"),
            (StyleProperties.BorderTopRight, $"{value}px"),
        };
    };
}

public sealed class BorderBottomGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded-b";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderBottomLeft, $"{value}px"),
            (StyleProperties.BorderBottomRight, $"{value}px"),
        };
    };
}

public sealed class BorderLeftGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded-l";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopLeft, $"{value}px"),
            (StyleProperties.BorderBottomLeft, $"{value}px"),
        };
    };
}

public sealed class BorderRightGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded-r";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopRight, $"{value}px"),
            (StyleProperties.BorderBottomRight, $"{value}px"),
        };
    };
}