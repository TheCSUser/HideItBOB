using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideDisastersButton : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideDisastersButton;

        private readonly ICheck _compatibilityCheck;
        public override bool IsAvailable => _compatibilityCheck.Result;

        public HideDisastersButton(IModContext context) : base(context, "WarningPhasePanel")
        {
            _compatibilityCheck = context.Resolve<NaturalDisastersDLCEnabledCheck>();
        }

        protected override bool OnTerminate()
        {
            _compatibilityCheck.Reset();
            return base.OnTerminate();
        }
    }
}