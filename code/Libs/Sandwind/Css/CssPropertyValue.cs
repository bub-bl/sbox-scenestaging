namespace Sandbox.Libs.Sandwind.Css;

public readonly struct CssPropertyValue
{
    private readonly object _value;

    private CssPropertyValue(object value)
    {
        _value = value;
    }

    public static implicit operator CssPropertyValue(float value) => new(value);
    public static implicit operator CssPropertyValue(short value) => new(value);
    public static implicit operator CssPropertyValue(int value) => new(value);
    public static implicit operator CssPropertyValue(string value) => new(value);
    
    public static implicit operator float(CssPropertyValue value) => Convert.ToSingle(value._value);
    public static implicit operator short(CssPropertyValue value) => Convert.ToInt16(value._value);
    public static implicit operator int(CssPropertyValue value) => Convert.ToInt32(value._value);
    public static implicit operator string(CssPropertyValue value) => Convert.ToString(value._value);

    public override string ToString() => _value.ToString();
}