using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideFreeCameraButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideFreeCameraButton;

        public HideFreeCameraButton(IModContext context) : base(context, "Freecamera") { }
    }
}