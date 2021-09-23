using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideGearButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideGearButton;

        public HideGearButton(IModContext context) : base(context, "Esc") { }
    }
}