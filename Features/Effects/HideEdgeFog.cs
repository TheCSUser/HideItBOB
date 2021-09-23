using com.github.TheCSUser.HideItBobby.Features.Effects.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HideEdgeFog : HideFog
    {
        public override FeatureKey Key => FeatureKey.HideEdgeFog;

        public HideEdgeFog(IModContext context) : base(context, Fields.Count) { }

        protected override void SaveValues()
        {
            Save(Fields.FogAmount, FogEffect.m_3DFogAmount);
        }
        protected override void SetEnabledValues()
        {
            FogProperties.m_edgeFog = false;
            FogEffect.m_edgeFog = false;
            FogEffect.m_3DFogAmount = 0.0f;
        }
        protected override void SetDisabledValues()
        {
            if (HasValue(Fields.FogAmount)) FogEffect.m_3DFogAmount = Restore(Fields.FogAmount);
            FogEffect.m_edgeFog = true;
            FogProperties.m_edgeFog = true;
        }

        private static class Fields
        {
            public const byte Count = 1;

            public const byte FogAmount = 0;
        }
    }
}