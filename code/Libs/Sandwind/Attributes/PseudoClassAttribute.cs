using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PseudoClassAttribute : Attribute
{
    public PseudoClass PseudoClass { get; }

    public PseudoClassAttribute(PseudoClass pseudoClass)
    {
        PseudoClass = pseudoClass;
    }
}