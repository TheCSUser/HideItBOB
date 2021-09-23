using com.github.TheCSUser.HideItBobby.Features.Effects.Shared.Patches;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HideBurnedAreaEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideBurnedAreaEffect;

        public HideBurnedAreaEffect(IModContext context) : base(context) { }

        protected override bool OnInitialize()
        {
            Patcher.Patch(NaturalResourceManagerProxy.UpdateTextureBPatch);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(NaturalResourceManagerProxy.UpdateTextureBPatch);
            return true;
        }

        protected override bool OnEnable()
        {
            NaturalResourceManagerProxy.HideBurnedAreaEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            NaturalResourceManagerProxy.HideBurnedAreaEffect = false;
            return true;
        }
    }
}