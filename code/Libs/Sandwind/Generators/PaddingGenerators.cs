using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class PaddingGeneratorBase : ExtendedPixelDimensionGenerator
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;
}

public sealed class PaddingGenerator : PaddingGeneratorBase
{
    protected override string ClassName => "p";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Padding, value),
        };
    };
}

public sealed class PaddingLeftGenerator : PaddingGeneratorBase
{
    protected override string ClassName => "pl";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.PaddingLeft, value),
        };
    };
}

public sealed class PaddingRightGenerator : PaddingGeneratorBase
{
    protected override string ClassName => "pr";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.PaddingRight, value),
        };
    };
}

public sealed class PaddingTopGenerator : PaddingGeneratorBase
{
    protected override string ClassName => "pt";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.PaddingTop, value),
        };
    };
}

public sealed class PaddingBottomGenerator : PaddingGeneratorBase
{
    protected override string ClassName => "pb";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.PaddingBottom, value),
        };
    };
}

public sealed class PaddingHorizontalGenerator : PaddingGeneratorBase
{
    protected override string ClassName => "px";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.PaddingLeft, value),
            (StyleProperties.PaddingRight, value)
        };
    };
}

public sealed class PaddingVerticalGenerator : PaddingGeneratorBase
{
    protected override string ClassName => "py";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.PaddingTop, value),
            (StyleProperties.PaddingBottom, value)
        };
    };
}