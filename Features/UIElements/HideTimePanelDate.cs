using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideTimePanelDate : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideTimePanel;

        public HideTimePanelDate(IModContext context) : base(context, "PanelTime") { }
    }
}