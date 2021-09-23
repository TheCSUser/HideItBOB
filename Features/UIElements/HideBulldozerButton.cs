using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideBulldozerButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideBulldozerButton;

        public HideBulldozerButton(IModContext context) : base(context, "BulldozerButton") { }
    }
}