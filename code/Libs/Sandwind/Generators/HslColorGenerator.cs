using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class HslColorGenerator : SandwindGeneratorBase
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;

    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) => new List<CssClassBuilder>()
        .Concat(GenerateHslColor(configFile, "slate", 211.76f, 30))
        .Concat(GenerateHslColor(configFile, "zinc", 211.76f, 15))
        .Concat(GenerateHslColor(configFile, "neutral", 0, 0))
        .Concat(GenerateHslColor(configFile, "stone", 0, 15))
        .Concat(GenerateHslColor(configFile, "red", 0))
        .Concat(GenerateHslColor(configFile, "orange", 21.17f))
        .Concat(GenerateHslColor(configFile, "amber", 42.35f))
        .Concat(GenerateHslColor(configFile, "yellow", 63.52f))
        .Concat(GenerateHslColor(configFile, "lime", 84.70f))
        .Concat(GenerateHslColor(configFile, "green", 105.88f))
        .Concat(GenerateHslColor(configFile, "emerald", 127.05f))
        .Concat(GenerateHslColor(configFile, "teal", 148.23f))
        .Concat(GenerateHslColor(configFile, "cyan", 169.41f))
        .Concat(GenerateHslColor(configFile, "sky", 190.58f))
        .Concat(GenerateHslColor(configFile, "blue", 211.76f))
        .Concat(GenerateHslColor(configFile, "indigo", 232.94f))
        .Concat(GenerateHslColor(configFile, "violet", 254.11f))
        .Concat(GenerateHslColor(configFile, "purple", 275.29f))
        .Concat(GenerateHslColor(configFile, "fuchsia", 296.47f))
        .Concat(GenerateHslColor(configFile, "pink", 317.64f))
        .Concat(GenerateHslColor(configFile, "rose", 338.82f));
}