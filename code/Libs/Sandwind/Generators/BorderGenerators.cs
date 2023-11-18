using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public sealed class BorderColorGenerator : HslColorGenerator
{
    protected override string ClassName => "border";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderColor, value),
        };
    };
}

public sealed class BorderTopColorGenerator : HslColorGenerator
{
    protected override string ClassName => "border-t";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopColor, value),
        };
    };
}

public sealed class BorderBottomColorGenerator : HslColorGenerator
{
    protected override string ClassName => "border-b";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderBottomColor, value),
        };
    };
}

public sealed class BorderLeftColorGenerator : HslColorGenerator
{
    protected override string ClassName => "border-l";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderLeftColor, value),
        };
    };
}

public sealed class BorderRightColorGenerator : HslColorGenerator
{
    protected override string ClassName => "border-r";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderRightColor, value),
        };
    };
}

public sealed class BorderHorizontalColorGenerator : HslColorGenerator
{
    protected override string ClassName => "border-x";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderLeftColor, value),
            (StyleProperties.BorderRightColor, value),
        };
    };
}

public sealed class BorderVerticalColorGenerator : HslColorGenerator
{
    protected override string ClassName => "border-y";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopColor, value),
            (StyleProperties.BorderBottomColor, value),
        };
    };
}

public abstract class BorderGeneratorBase : SandwindGeneratorBase
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;

    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) => new List<CssClassBuilder>()
        .Concat(GenerateIncrementals(configFile, 0, 8, .5f, 8f))
        .Concat(GenerateIncrementals(configFile, 4, 8, 1f, 16f));
}

public sealed class BorderWidthGenerator : BorderGeneratorBase
{
    protected override string ClassName => "border";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderWidth, value),
        };
    };
}

public sealed class BorderTopWidthGenerator : BorderGeneratorBase
{
    protected override string ClassName => "border-t";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopWidth, value),
        };
    };
}

public sealed class BorderBottomWidthGenerator : BorderGeneratorBase
{
    protected override string ClassName => "border-b";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderBottomWidth, value),
        };
    };
}

public sealed class BorderLeftWidthGenerator : BorderGeneratorBase
{
    protected override string ClassName => "border-l";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderLeftWidth, value),
        };
    };
}

public sealed class BorderRightWidthGenerator : BorderGeneratorBase
{
    protected override string ClassName => "border-r";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderRightWidth, value),
        };
    };
}

public sealed class BorderHorizontalWidthGenerator : BorderGeneratorBase
{
    protected override string ClassName => "border-x";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderLeftWidth, value),
            (StyleProperties.BorderRightWidth, value),
        };
    };
}

public sealed class BorderVerticalWidthGenerator : BorderGeneratorBase
{
    protected override string ClassName => "border-y";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderTopWidth, value),
            (StyleProperties.BorderBottomWidth, value),
        };
    };
}

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