using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideTimePanel : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideTimePanel;

        public HideTimePanel(IModContext context) : base(context, "PanelTime") { }
    }
}