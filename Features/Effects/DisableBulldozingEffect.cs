using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.HideItBobby.Features.Effects.Shared;
using com.github.TheCSUser.Shared.Checks;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class DisableBulldozingEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.DisableBulldozingEffect;

        private readonly IPluginCheck _check;
        public override bool IsAvailable => _check.IsDisabled;

        private readonly DispatchPlacementEffectProxy _dispatchPlacementEffectProxy;

        public DisableBulldozingEffect(IModContext context) : base(context)
        {
            _check = context.Resolve<ModCheck>(Mods.SubtleBulldozing);
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
            _dispatchPlacementEffectProxy.DisableBulldozingEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            _dispatchPlacementEffectProxy.DisableBulldozingEffect = false;
            return true;
        }
    }
}