
using ColossalFramework;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor
{
    internal sealed class DisableDirtyWaterColor : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.DisableDirtyWaterColor;

        public DisableDirtyWaterColor(IModContext context) : base(context) { }

        protected override bool OnEnable()
        {
            if (!Singleton<TerrainManager>.exists)
            {
#if DEV
                Log.Warning($"{nameof(DisableDirtyWaterColor)}.{nameof(OnEnable)} instance of {nameof(TerrainManager)} does not exist");
#endif
                return false;
            }
            var properties = Singleton<TerrainManager>.instance?.m_properties;
            if (properties is null)
            {
#if DEV
                Log.Warning($"{nameof(DisableDirtyWaterColor)}.{nameof(OnEnable)} instance of {nameof(TerrainProperties)} does not exist");
#endif
                return false;
            }

            var cleanWaterColor = new Color(
                properties.m_waterColorClean.r,
                properties.m_waterColorClean.g,
                properties.m_waterColorClean.b,
                properties.m_waterRainFoam);
            Shader.SetGlobalColor("_WaterColorDirty", cleanWaterColor);
            return true;
        }
        protected override bool OnDisable()
        {
            if (!Singleton<TerrainManager>.exists)
            {
#if DEV
                Log.Warning($"{nameof(DisableDirtyWaterColor)}.{nameof(OnDisable)} instance of {nameof(TerrainManager)} does not exist");
#endif
                return false;
            }
            var properties = Singleton<TerrainManager>.instance?.m_properties;
            if (properties is null)
            {
#if DEV
                Log.Warning($"{nameof(DisableDirtyWaterColor)}.{nameof(OnEnable)} instance of {nameof(TerrainProperties)} does not exist");
#endif
                return false;
            }

            Shader.SetGlobalColor("_WaterColorDirty", properties.m_waterColorDirty);
            return true;
        }

    }
}