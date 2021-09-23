using com.github.TheCSUser.HideItBobby.Features.Effects.Shared.Patches;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HideShoreAreaEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideShoreAreaEffect;

        public HideShoreAreaEffect(IModContext context) : base(context) { }

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
            NaturalResourceManagerProxy.HideShoreAreaEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            NaturalResourceManagerProxy.HideShoreAreaEffect = false;
            return true;
        }
    }
}