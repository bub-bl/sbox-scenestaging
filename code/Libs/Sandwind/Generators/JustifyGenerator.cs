using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.Libs.Sandwind.Css.Properties;

namespace Sandbox.Libs.Sandwind.Generators;

public sealed class JustifyGenerator : SandwindGeneratorBase
{
    protected override string ClassName => "justify";

    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.JustifyContent, value),
        };
    };

    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) =>
        new List<CssClassBuilder>(GenerateValues(configFile, Justify));
}