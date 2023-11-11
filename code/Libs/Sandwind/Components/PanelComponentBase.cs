using Sandbox.Libs.Sandwind.Css.Properties;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind.Components;

public abstract class PanelComponentBase : Panel, IPosition
{
    public Position Position { get; set; }
}