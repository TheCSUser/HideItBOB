using com.github.TheCSUser.HideItBobby.Features.Effects.Shared.Patches;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HideOreAreaEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideOreAreaEffect;

        public HideOreAreaEffect(IModContext context) : base(context) { }

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
            NaturalResourceManagerProxy.HideOreAreaEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            NaturalResourceManagerProxy.HideOreAreaEffect = false;
            return true;
        }
    }
}