using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideCinematicCameraButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideCinematicCameraButton;

        public HideCinematicCameraButton(IModContext context) : base(context, "CinematicCameraPanel") { }
    }
}