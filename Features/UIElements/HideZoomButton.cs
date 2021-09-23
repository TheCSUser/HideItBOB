using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideZoomButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideZoomButton;

        public HideZoomButton(IModContext context) : base(context, "ZoomComposite") { }
    }
}