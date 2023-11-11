using System.Globalization;

namespace Sandbox.Libs.Sandwind.CssHelpers.Helpers;

public static class CssUnitsHelper
{
    private static string ToInvariant(object value) => value switch
    {
        float f => f.ToString(CultureInfo.InvariantCulture),
        double d => d.ToString(CultureInfo.InvariantCulture),
        decimal dec => dec.ToString(CultureInfo.InvariantCulture),
        _ => value.ToString()
    };

    public static string ToPixel(object value) => $"{ToInvariant(value)}px";
    public static string ToVw(object value) => $"{ToInvariant(value)}vw";
    public static string ToVh(object value) => $"{ToInvariant(value)}vh";
    public static string ToPercentage(float value) => $"{ToInvariant(value)}%";
    public static string ToRem(float value) => $"{ToInvariant(value)}rem";
    public static string ToEm(float value) => $"{ToInvariant(value)}em";
    public static string ToRadiant(float value) => $"{ToInvariant(value)}rad";
}