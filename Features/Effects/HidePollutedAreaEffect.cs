using com.github.TheCSUser.HideItBobby.Features.Effects.Shared.Patches;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HidePollutedAreaEffect : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HidePollutedAreaEffect;

        public HidePollutedAreaEffect(IModContext context) : base(context) { }

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
            NaturalResourceManagerProxy.HidePollutedAreaEffect = true;
            return true;
        }
        protected override bool OnDisable()
        {
            NaturalResourceManagerProxy.HidePollutedAreaEffect = false;
            return true;
        }
    }
}