using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class WidthGeneratorBase : ResponsivePixelDimensionGenerator
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;
}

public sealed class WidthGenerator : WidthGeneratorBase
{
    protected override string ClassName => "w";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Width, value),
        };
    };
}

public sealed class MinWidthGenerator : WidthGeneratorBase
{
    protected override string ClassName => "min-w";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MinWidth, value),
        };
    };
}

public sealed class MaxWidthGenerator : WidthGeneratorBase
{
    protected override string ClassName => "max-w";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MaxWidth, value),
        };
    };
}