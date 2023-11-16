using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css.Helpers;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class SizePixelDimensionGenerator : SandwindGeneratorBase
{
    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) =>
        new List<CssClassBuilder>(GenerateSizes(configFile));
}