using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class MarginGeneratorBase : ExtendedPixelDimensionGenerator
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;
}

public sealed class MarginGenerator : MarginGeneratorBase
{
    protected override string ClassName => "m";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Margin, value),
        };
    };
}

public sealed class MarginLeftGenerator : MarginGeneratorBase
{
    protected override string ClassName => "ml";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MarginLeft, value),
        };
    };
}

public sealed class MarginRightGenerator : MarginGeneratorBase
{
    protected override string ClassName => "mr";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MarginRight, value),
        };
    };
}

public sealed class MarginTopGenerator : MarginGeneratorBase
{
    protected override string ClassName => "mt";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MarginTop, value),
        };
    };
}

public sealed class MarginBottomGenerator : MarginGeneratorBase
{
    protected override string ClassName => "mb";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MarginBottom, value),
        };
    };
}

public sealed class MarginHorizontalGenerator : MarginGeneratorBase
{
    protected override string ClassName => "mx";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MarginLeft, value),
            (StyleProperties.MarginRight, value)
        };
    };
}

public sealed class MarginVerticalGenerator : MarginGeneratorBase
{
    protected override string ClassName => "my";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MarginTop, value),
            (StyleProperties.MarginBottom, value)
        };
    };
}