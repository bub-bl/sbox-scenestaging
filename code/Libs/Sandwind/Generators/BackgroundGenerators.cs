using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public sealed class BackgroundColorGenerator : HslColorGenerator
{
    protected override string ClassName => "bg";
    protected override PseudoClass PseudoClass => PseudoClass.Hover;

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = (float)args[2];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BackgroundColor, value),
        };
    };
}

public sealed class BackgroundRepeatGenerator : SandwindGeneratorBase
{
    protected override string ClassName => "bg";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BackgroundRepeat, value),
        };
    };

    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) =>
        new List<CssClassBuilder>(GenerateValues(configFile, BackgroundRepeat));
}

public sealed class BackgroundPositionGenerator : SandwindGeneratorBase
{
    protected override string ClassName => "bg";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.BackgroundPosition, value),
        };
    };

    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) =>
        new List<CssClassBuilder>(GenerateValues(configFile, BackgroundPosition));
}

// public sealed class BackgroundSizeGenerator : SandwindGeneratorBase
// {
//     protected override string ClassName => "bg";
//
//     protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
//     {
//         var value = args[1];
//
//         return new List<(CssProperty, object)>
//         {
//             (StyleProperties.BackgroundSize, value),
//         };
//     };
//
//     public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) =>
//         new List<CssClassBuilder>(GenerateValues(configFile, BackgroundSize));
// }