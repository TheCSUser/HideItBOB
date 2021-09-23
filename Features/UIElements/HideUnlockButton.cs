using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideUnlockButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideUnlockButton;

        public HideUnlockButton(IModContext context) : base(context, "UnlockButton") { }
    }
}