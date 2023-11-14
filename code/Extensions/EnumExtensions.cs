using System.Collections.Generic;

namespace Sandbox.Extensions;

public static class EnumExtensions
{
    public static IEnumerable<T> GetFlags<T>(this T input) where T : Enum =>
        Enum.GetValues(typeof(T)).Cast<T>().Where(x => input.HasFlag(x));
}
