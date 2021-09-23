
using com.github.TheCSUser.HideItBobby.Features.Effects.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HidePollutionFog : HideFog
    {
        public override FeatureKey Key => FeatureKey.HidePollutionFog;

        public HidePollutionFog(IModContext context) : base(context, Fields.Count) { }

        protected override void SaveValues()
        {
            Save(Fields.PollutionAmount, FogProperties.m_PollutionAmount);
            Save(Fields.PollutionIntensityWater, FogEffect.m_PollutionIntensityWater);
            Save(Fields.PollutionIntensity, FogEffect.m_PollutionIntensity);

            if (!(RenderProperties is null))
            {
                Save(Fields.PollutionFogIntensityWater, RenderProperties.m_pollutionFogIntensityWater);
                Save(Fields.PollutionFogIntensity, RenderProperties.m_pollutionFogIntensity);
            }
            else
            {
                Save(Fields.PollutionFogIntensityWater, null);
                Save(Fields.PollutionFogIntensity, null);
            }
        }
        protected override void SetEnabledValues()
        {
            FogProperties.m_PollutionAmount = 0f;
            FogEffect.m_PollutionIntensityWater = 0f;
            FogEffect.m_PollutionIntensity = 0f;

            if (!(RenderProperties is null))
            {
                RenderProperties.m_pollutionFogIntensityWater = 0f;
                RenderProperties.m_pollutionFogIntensity = 0f;
            }
        }
        protected override void SetDisabledValues()
        {
            if (HasValue(Fields.PollutionAmount)) FogProperties.m_PollutionAmount = Restore(Fields.PollutionAmount);
            if (HasValue(Fields.PollutionIntensityWater)) FogEffect.m_PollutionIntensityWater = Restore(Fields.PollutionIntensityWater);
            if (HasValue(Fields.PollutionIntensity)) FogEffect.m_PollutionIntensity = Restore(Fields.PollutionIntensity);

            if (!(RenderProperties is null))
            {
                if (HasValue(Fields.PollutionFogIntensityWater)) RenderProperties.m_pollutionFogIntensityWater = Restore(Fields.PollutionFogIntensityWater);
                if (HasValue(Fields.PollutionFogIntensity)) RenderProperties.m_pollutionFogIntensity = Restore(Fields.PollutionFogIntensity);
            }
        }

        private static class Fields
        {
            public const byte Count = 5;

            public const byte PollutionAmount = 0;
            public const byte PollutionIntensityWater = 1;
            public const byte PollutionIntensity = 2;
            public const byte PollutionFogIntensityWater = 3;
            public const byte PollutionFogIntensity = 4;
        }
    }
}