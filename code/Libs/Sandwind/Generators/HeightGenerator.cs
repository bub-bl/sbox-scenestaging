using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;

namespace Sandbox.Libs.Sandwind.Generators;

public sealed class HeightGenerator : DimensionGeneratorBase
{
    protected override string ClassType => "h";
    protected override CssProperty DimensionProperty => StyleProperties.Height;
}