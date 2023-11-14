using System.Collections.Generic;
using Sandbox.Libs.Sandwind.CssHelpers.Helpers;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class ScssClassGeneratorBase
{
    protected virtual PseudoClass PseudoClass { get; }

    protected static string GetPrefix(SandwindConfigFile configFile) =>
        !string.IsNullOrEmpty(configFile.ClassPrefix) ? $"{configFile.ClassPrefix}-" : string.Empty;

    public abstract IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile);
}