using System.Collections.Generic;
using System.Text;
using Sandbox.Extensions;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Css.Helpers;

public class CssClassBuilder
{
    private string _className;
    private PseudoClass _pseudoClass;
    private List<(CssProperty Property, CssPropertyValue Value)> _properties = new();

    private StringBuilder _builder = new();

    public CssClassBuilder WithClassName(string className)
    {
        _className = className;
        return this;
    }

    public CssClassBuilder WithPseudoClass(PseudoClass pseudoClass)
    {
        _pseudoClass = pseudoClass;
        return this;
    }

    public CssClassBuilder WithProperty(CssProperty property, CssPropertyValue value)
    {
        _properties.Add((property, value));
        return this;
    }
    
    private string BuildClassName(PseudoClass pseudoClass)
    {
        var isValid = pseudoClass is not PseudoClass.None;
        var str = pseudoClass.ToString().ToLower();
        var result = new StringBuilder();

        result.Append('.');

        if (isValid)
        {
            result.Append(str);
            result.Append('|');
        }

        result.Append(_className);

        if (isValid)
        {
            result.Append(':');
            result.Append(str);
        }

        return result.ToString();
    }

    public string Build()
    {
        foreach (var pseudoClass in _pseudoClass.GetFlags())
        {
            _builder.Append(BuildClassName(pseudoClass));
            _builder.AppendLine(" {");

            foreach (var prop in _properties)
            {
                var style = new StyleBuilder()
                    .AddStyle(prop.Property, prop.Value)
                    .Build();

                _builder.AppendLine($"\t{style}");
            }

            _builder.AppendLine("}");    
        }
        
        return _builder.ToString();
    }
}