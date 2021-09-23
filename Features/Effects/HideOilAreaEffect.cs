using com.github.TheCSUser.HideItBobby.Features.Effects.Shared.Patches;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HideOilAreaEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideOilAreaEffect;

        public HideOilAreaEffect(IModContext context) : base(context) { }

        protected override bool OnInitialize()
        {
            Patcher.Patch(NaturalResourceManagerProxy.UpdateTexturePatch);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(NaturalResourceManagerProxy.UpdateTexturePatch);
            return true;
        }

        protected override bool OnEnable()
        {
            NaturalResourceManagerProxy.HideOilAreaEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            NaturalResourceManagerProxy.HideOilAreaEffect = false;
            return true;
        }
    }
}