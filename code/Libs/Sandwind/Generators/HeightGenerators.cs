using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class HeightGeneratorBase : ResponsivePixelDimensionGenerator
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;
}

public sealed class HeightGenerator : HeightGeneratorBase
{
    protected override string ClassName => "h";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Height, value),
        };
    };
}

public sealed class MinHeightGenerator : HeightGeneratorBase
{
    protected override string ClassName => "min-h";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MinHeight, value),
        };
    };
}

public sealed class MaxHeightGenerator : HeightGeneratorBase
{
    protected override string ClassName => "max-h";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.MaxHeight, value),
        };
    };
}