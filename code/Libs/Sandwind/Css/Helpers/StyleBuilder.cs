namespace Sandbox.Libs.Sandwind.Css.Helpers;

public sealed class StyleBuilder
{
    private string _style = string.Empty;

    private StyleBuilder AddRow(string property, object value)
    {
        _style += $"{property}: {value};";
        return this;
    }

    private StyleBuilder AddStyle(StyleBuilder style)
    {
        _style += style.Build();
        return this;
    }

    public StyleBuilder AddStyle(ICssProperty property, bool when = true) =>
        when ? AddRow(property.Name, property.Value) : this;

    public StyleBuilder AddStyle(string property, object value, bool when = true) =>
        when ? AddRow(property, value) : this;

    public StyleBuilder AddStyle(StyleBuilder builder, bool when = true) => when ? AddStyle(builder) : this;

    public string Build() => _style.Trim();
    public string? NullIfEmpty() => string.IsNullOrEmpty(Build()) ? null : string.Empty;
    public override string ToString() => Build();
}