using Sandbox.Libs.Sandwind;
using Sandbox.Libs.Sandwind.Css.Helpers;
using Sandbox.Libs.Sandwind.Css.Properties;

namespace GameObjects;

[TestClass]
public class SandwindComponents
{
	[TestMethod]
	public void CssProperty_DynamicStringCast()
	{
		var pos = Position.Absolute;

		Assert.AreEqual("absolute", pos);
		Assert.AreEqual(Position.Absolute, pos);
	}
	
	[TestMethod]
	public void CssProperty_BuildStyleBuilder()
	{
		var pos = Position.Absolute;
		const string prop = "position: absolute;";
		
		Assert.AreEqual(prop, new StyleBuilder().AddStyle(pos).Build());
		Assert.AreEqual(prop, new StyleBuilder().AddStyle("position", "absolute").Build());
	}
	
	[TestMethod]
	public void CssProperty_CssUnits()
	{
		const int widthInt = 45;
		const float widthFloat = 45.4f;

		Assert.AreEqual("45px", CssUnitsHelper.ToPixel(widthInt));
		Assert.AreEqual("45em", CssUnitsHelper.ToEm(widthInt));
		Assert.AreEqual("45.4rad", CssUnitsHelper.ToRadiant(widthFloat));
		Assert.AreEqual("45.4%", CssUnitsHelper.ToPercentage(widthFloat));
	}
}