using com.github.TheCSUser.HideItBobby.Features.Effects.Shared.Patches;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HideDestroyedAreaEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideDestroyedAreaEffect;

        public HideDestroyedAreaEffect(IModContext context) : base(context) { }

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
            NaturalResourceManagerProxy.HideDestroyedAreaEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            NaturalResourceManagerProxy.HideDestroyedAreaEffect = false;
            return true;
        }
    }
}