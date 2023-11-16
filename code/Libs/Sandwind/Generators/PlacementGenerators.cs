using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class PlacementGeneratorBase : ResponsivePixelDimensionGenerator
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;
}

public sealed class TopGenerator : PlacementGeneratorBase
{
    protected override string ClassName => "top";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Top, value),
        };
    };
}

public sealed class BottomGenerator : PlacementGeneratorBase
{
    protected override string ClassName => "bottom";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Bottom, value),
        };
    };
}

public sealed class LeftGenerator : PlacementGeneratorBase
{
    protected override string ClassName => "left";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Left, value),
        };
    };
}

public sealed class RightGenerator : PlacementGeneratorBase
{
    protected override string ClassName => "right";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Right, value),
        };
    };
}