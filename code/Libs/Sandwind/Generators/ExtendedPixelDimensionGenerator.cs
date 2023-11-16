using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css.Helpers;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class ExtendedPixelDimensionGenerator : SandwindGeneratorBase
{
    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) => new List<CssClassBuilder>()
        .Concat(GenerateIncrementals(configFile, 0, 8, .5f, 8f))
        .Concat(GenerateIncrementals(configFile, 4, 8, 1f, 16f))
        .Concat(GenerateIncrementals(configFile, 6, 2, 2f, 32f))
        .Concat(GenerateIncrementals(configFile, 4, 12, 4f, 64f))
        .Concat(GenerateIncrementals(configFile, 8, 4, 8f, 128f));
}