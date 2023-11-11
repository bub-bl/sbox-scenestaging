using System.Text;

namespace Sandbox.Libs.Sandwind.CssHelpers.Helpers;

public sealed class CssBuilder
{
    private readonly StringBuilder _builder = new();

    private CssBuilder AddClass(string className)
    {
        _builder.Append(' ');
        _builder.Append(className);

        return this;
    }

    public CssBuilder AddClass(string className, bool when = true) => when ? AddClass(className) : this;
    public CssBuilder AddClass(CssBuilder builder, bool when = true) => when ? AddClass(builder.Build()) : this;

    public string Build() => _builder.ToString().Trim();
    public string? NullIfEmpty() => string.IsNullOrEmpty(Build()) ? null : string.Empty;
    public override string ToString() => Build();
}