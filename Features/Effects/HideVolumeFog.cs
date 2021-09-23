using com.github.TheCSUser.HideItBobby.Features.Effects.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HideVolumeFog : HideFog
    {
        public override FeatureKey Key => FeatureKey.HideVolumeFog;

        public HideVolumeFog(IModContext context) : base(context, Fields.Count) { }

        protected override void SaveValues()
        {
            Save(Fields.FogDensity, FogProperties.m_FogDensity);

            if (!(RenderProperties is null))
            {
                Save(Fields.VolumeFogDensity, RenderProperties.m_volumeFogDensity);
            }
            else
            {
                Save(Fields.VolumeFogDensity, null);
            }
        }
        protected override void SetEnabledValues()
        {
            FogProperties.m_FogDensity = 0f;
            FogEffect.m_UseVolumeFog = false;

            if (!(RenderProperties is null))
            {
                RenderProperties.m_volumeFogDensity = 0f;
                RenderProperties.m_useVolumeFog = false;
            }
        }
        protected override void SetDisabledValues()
        {
            if (HasValue(Fields.FogDensity)) FogProperties.m_FogDensity = Restore(Fields.FogDensity);
            FogEffect.m_UseVolumeFog = true;

            if (!(RenderProperties is null))
            {
                if (HasValue(Fields.VolumeFogDensity)) RenderProperties.m_volumeFogDensity = Restore(Fields.VolumeFogDensity);
                RenderProperties.m_useVolumeFog = true;
            }
        }

        private static class Fields
        {
            public const byte Count = 2;

            public const byte FogDensity = 0;
            public const byte VolumeFogDensity = 1;
        }
    }
}