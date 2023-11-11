namespace Sandbox.Libs.Sandwind.Css.Properties;

public static class StyleProperties
{
    public static CssProperty Background => new("background");
    public static CssProperty Foreground => new("foreground");
    public static CssProperty BackgroundColor => new("background-color");
    public static CssProperty Color => new("color");
    public static CssProperty Position => new("position");
    public static CssProperty Display => new("display");
    public static CssProperty MinWidth => new("min-width");
    public static CssProperty MinHeight => new("min-height");
    public static CssProperty MaxWidth => new("max-width");
    public static CssProperty MaxHeight => new("max-height");
    public static CssProperty Width => new("width");
    public static CssProperty Height => new("height");
}