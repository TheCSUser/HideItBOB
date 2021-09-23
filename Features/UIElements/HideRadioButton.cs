using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideRadioButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideRadioButton;

        public HideRadioButton(IModContext context) : base(context, "RadioButton") { }
    }
}