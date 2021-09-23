using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideInfoViewsButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideInfoViewsButton;

        public HideInfoViewsButton(IModContext context) : base(context, "InfoMenu") { }
    }
}