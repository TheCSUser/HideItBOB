using com.github.TheCSUser.HideItBobby.Features.Effects.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Effects
{
    internal sealed class HideDistanceFog : HideFog
    {
        public override FeatureKey Key => FeatureKey.HideDistanceFog;

        public HideDistanceFog(IModContext context) : base(context, Fields.Count) { }

        protected override void SaveValues()
        {
            Save(Fields.ColorDecay, FogProperties.m_ColorDecay);
        }
        protected override void SetEnabledValues()
        {
            FogProperties.m_ColorDecay = 1f;
        }
        protected override void SetDisabledValues()
        {
            if (HasValue(Fields.ColorDecay)) FogProperties.m_ColorDecay = Restore(Fields.ColorDecay);
        }

        private static class Fields
        {
            public const byte Count = 1;

            public const byte ColorDecay = 0;
        }
    }
}