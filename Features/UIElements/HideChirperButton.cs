using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideChirperButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideChirperButton;

        public HideChirperButton(IModContext context) : base(context, "ChirperPanel") { }
    }
}