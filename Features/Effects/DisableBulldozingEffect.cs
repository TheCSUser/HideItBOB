using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.HideItBobby.Features.Effects.Shared;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class DisableBulldozingEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.DisableBulldozingEffect;

        private readonly ICheck _compatibilityCheck;
        public override bool IsAvailable => _compatibilityCheck.Result;

        public DisableBulldozingEffect(IModContext context) : base(context)
        {
            _compatibilityCheck = context.Resolve<SubtleBulldozingModDisabledCheck>();
        }

        protected override bool OnInitialize()
        {
            Patcher.Patch(DispatchPlacementEffectProxy.Patches);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(DispatchPlacementEffectProxy.Patches);
            return true;
        }

        protected override bool OnEnable()
        {
            DispatchPlacementEffectProxy.DisableBulldozingEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            DispatchPlacementEffectProxy.DisableBulldozingEffect = false;
            return true;
        }
    }
}