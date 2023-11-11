using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PseudoClassesAttribute : Attribute
{
    public PseudoClass PseudoClass { get; }

    public PseudoClassesAttribute(PseudoClass pseudoClass)
    {
        PseudoClass = pseudoClass;
    }
}