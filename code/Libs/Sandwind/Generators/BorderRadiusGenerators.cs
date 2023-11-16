using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class BorderRadiusGeneratorBase : SizePixelDimensionGenerator
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;
}

public sealed class BorderRadiusGenerator : BorderRadiusGeneratorBase
{
    protected override string ClassName => "rounded";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BorderRadius, value),
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
            (StyleProperties.BorderTopLeft, value),
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
            (StyleProperties.BorderBottomLeft, value),
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
            (StyleProperties.BorderTopRight, value),
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
            (StyleProperties.BorderBottomRight, value),
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
            (StyleProperties.BorderTopLeft, value),
            (StyleProperties.BorderTopRight, value),
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
            (StyleProperties.BorderBottomLeft, value),
            (StyleProperties.BorderBottomRight, value),
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
            (StyleProperties.BorderTopLeft, value),
            (StyleProperties.BorderBottomLeft, value),
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
            (StyleProperties.BorderTopRight, value),
            (StyleProperties.BorderBottomRight, value),
        };
    };
}