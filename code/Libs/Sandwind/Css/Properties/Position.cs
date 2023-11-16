namespace Sandbox.Libs.Sandwind.Css.Properties;

public readonly record struct Position : ICssProperty
{
    public CssProperty Name => StyleProperties.Position;
    public CssPropertyValue Value { get; }

    private Position(CssPropertyValue value)
    {
        Value = value;
    }

    public static readonly Position Relative = new("relative");
    public static readonly Position Absolute = new("absolute");
    public static readonly Position Static = new("static");
    public static readonly Position Fixed = new("fixed");
    public static readonly Position Sticky = new("sticky");
    
    public static implicit operator string(Position value) => value.Value;

    public override string ToString() => Value.ToString();
}