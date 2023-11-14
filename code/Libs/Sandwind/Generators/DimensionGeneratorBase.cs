using System.Collections.Generic;
using Sandbox.Extensions;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.CssHelpers.Helpers;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class DimensionGeneratorBase : ScssClassGeneratorBase
{
    protected const int DefaultStepCount = 8;
    protected const int DefaultStepValue = 8;

    protected virtual int StepCount { get; } = DefaultStepCount;
    protected virtual int StepValue { get; } = DefaultStepValue;
    protected override PseudoClass PseudoClass => PseudoClass.Focus | PseudoClass.Active;
    protected abstract string ClassType { get; }
    protected abstract CssProperty DimensionProperty { get; }

    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile)
    {
        var classPrefix = GetPrefix(configFile);

        for (var i = 0; i < StepCount; i++)
        {
            var value = i * StepValue;

            var classBuilder = new CssClassBuilder()
                .WithClassName($"{classPrefix}{ClassType}-{value}")
                .WithProperty(DimensionProperty, $"{value}px");

            yield return classBuilder;

            foreach (var flag in PseudoClass.GetFlags().Where(x => x is not PseudoClass.None))
            {
                classBuilder = classBuilder
                    .WithPseudoClass(flag);

                yield return classBuilder;
            }
        }
    }
}