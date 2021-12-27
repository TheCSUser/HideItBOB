using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Checks;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideDisastersButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideDisastersButton;

        private readonly DLCCheck _check;
        public override bool IsAvailable => _check.IsEnabled;

        public HideDisastersButton(IModContext context) : base(context, "WarningPhasePanel")
        {
            _check = context.Resolve<DLCCheck>(DLC.NaturalDisasters);
        }
    }
}