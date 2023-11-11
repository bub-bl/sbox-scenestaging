using System.Collections.Generic;
using System.Text;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.Libs.Sandwind.Css.Helpers;

namespace Sandbox.Libs.Sandwind.CssHelpers.Helpers;

public class CssClassBuilder
{
    private string _className;
    private List<(CssProperty Property, CssPropertyValue Value)> _properties = new();

    private StringBuilder _builder = new();

    public CssClassBuilder WithClassName(string className)
    {
        _className = className;
        return this;
    }

    public CssClassBuilder WithProperty(CssProperty property, CssPropertyValue value)
    {
        _properties.Add((property, value));
        return this;
    }

    public string Build()
    {
        _builder.AppendLine($".{_className}");
        _builder.AppendLine("{");

        foreach (var prop in _properties)
        {
            var style = new StyleBuilder()
                .AddStyle(prop.Property, prop.Value)
                .Build();
            
            _builder.AppendLine($"\t{style}");
        }

        _builder.AppendLine("}");
        return _builder.ToString();
    }
}