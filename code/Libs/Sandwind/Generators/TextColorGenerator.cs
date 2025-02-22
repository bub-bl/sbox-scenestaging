﻿using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;

namespace Sandbox.Libs.Sandwind.Generators;

public sealed class TextColorGenerator : HslColorGenerator
{
    protected override string ClassName => "text";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.Color, value),
        };
    };
}