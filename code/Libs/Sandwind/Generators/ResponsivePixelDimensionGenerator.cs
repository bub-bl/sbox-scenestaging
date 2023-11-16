using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css.Helpers;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class ResponsivePixelDimensionGenerator : ExtendedPixelDimensionGenerator
{
    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) =>
        base.Build(configFile)
            .Concat(GenerateFractionals(configFile, 4))
            .Concat(GenerateFractionals(configFile, 5))
            .Concat(GenerateFractionals(configFile, 6))
            .Concat(GenerateFractionals(configFile, 12));
}