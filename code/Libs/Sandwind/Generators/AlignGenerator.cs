using System.Collections.Generic;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Generators;

public abstract class AlignGeneratorBase : SandwindGeneratorBase
{
    protected override PseudoClass PseudoClass => PseudoClass.Hover;
    
    public override IEnumerable<CssClassBuilder> Build(SandwindConfigFile configFile) =>
        new List<CssClassBuilder>(GenerateValues(configFile, Align));
}

public sealed class AlignContentGenerator : AlignGeneratorBase
{
    protected override string ClassName => "content";
    
    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.AlignContent, value),
        };
    };
}

public sealed class AlignItemsGenerator : AlignGeneratorBase
{
    protected override string ClassName => "items";
    
    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.AlignItems, value),
        };
    };
}

public sealed class AlignSelfGenerator : AlignGeneratorBase
{
    protected override string ClassName => "self";
    
    protected override Func<object[], List<(CssProperty, object)>> Properties => args =>
    {
        var value = args[1];

        return new List<(CssProperty, object)>
        {
            (StyleProperties.AlignSelf, value),
        };
    };
}