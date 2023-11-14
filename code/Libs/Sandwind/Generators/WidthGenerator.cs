using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Properties;

namespace Sandbox.Libs.Sandwind.Generators;

public sealed class WidthGenerator : DimensionGeneratorBase
{
    protected override string ClassType => "w";
    protected override CssProperty DimensionProperty => StyleProperties.Width;
}