using System.Collections.Generic;
using Sandbox.Libs.Sandwind.CssHelpers.Helpers;

namespace Sandbox.Libs.Sandwind;

public abstract class ClassGeneratorBase
{
    public abstract string ClassName { get; }

    public abstract List<CssClassBuilder> Build();
}