using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.HideItBobby.Features.Effects.Shared;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class DisablePlacementEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.DisablePlacementEffect;

        private readonly ICheck _compatibilityCheck;
        public override bool IsAvailable => _compatibilityCheck.Result;

        private readonly DispatchPlacementEffectProxy _dispatchPlacementEffectProxy;

        public DisablePlacementEffect(IModContext context) : base(context)
        {
            _compatibilityCheck = context.Resolve<SubtleBulldozingModDisabledCheck>();
            _dispatchPlacementEffectProxy = context.Resolve<DispatchPlacementEffectProxy>();
        }

        protected override bool OnInitialize()
        {
            Patcher.Patch(_dispatchPlacementEffectProxy.Patches);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(_dispatchPlacementEffectProxy.Patches);
            return true;
        }

        protected override bool OnEnable()
        {
            _dispatchPlacementEffectProxy.DisablePlacementEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            _dispatchPlacementEffectProxy.DisablePlacementEffect = false;
            return true;
        }
    }
}