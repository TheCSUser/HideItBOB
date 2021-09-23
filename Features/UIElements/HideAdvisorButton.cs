using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideAdvisorButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideAdvisorButton;

        public HideAdvisorButton(IModContext context) : base(context, "AdvisorButton") { }
    }
}