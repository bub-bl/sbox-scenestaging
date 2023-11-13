namespace Sandbox.Libs.Sandwind.Css;

public struct CssProperty
{
    public string Name { get; set; }
    
    public CssProperty(string name)
    {
        Name = name;
    }
    
    public static implicit operator string(CssProperty property) => property.Name;

    public override string ToString() => Name;
}