using ColossalFramework;
using com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor.Shared;
using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor
{
    internal sealed class DisableGrassPollutionGroundColor : FeatureBase
    {
        private const string ShaderName = "_GrassPollutionColorOffset";

        public override FeatureKey Key => FeatureKey.DisableGrassPollutionGroundColor;
        private Vector4 DefaultColorOffset;

        public DisableGrassPollutionGroundColor(IModContext context) : base(context) { }

        protected override bool OnEnable()
        {
            if (!Singleton<TerrainManager>.exists)
            {
#if DEV
                Log.Warning($"{nameof(DisableGrassPollutionGroundColor)}.{nameof(OnEnable)} instance of {nameof(TerrainManager)} does not exist");
#endif
                return false;
            }

            var properties = Singleton<TerrainManager>.instance?.m_properties;
            if (properties is null)
            {
#if DEV
                Log.Warning($"{nameof(DisableGrassPollutionGroundColor)}.{nameof(OnEnable)} instance of {nameof(TerrainProperties)} does not exist");
#endif
                return false;
            }

            if (DefaultColorOffset == GroundColorOffset.None) DefaultColorOffset = Shader.GetGlobalVector(ShaderName);
            Shader.SetGlobalVector(ShaderName, new Vector4(GroundColorOffset.None.x, GroundColorOffset.None.y, GroundColorOffset.None.z, properties.m_cliffSandNormalTiling));
            return true;
        }
        protected override bool OnDisable()
        {
            if (!Singleton<TerrainManager>.exists)
            {
#if DEV
                Log.Warning($"{nameof(DisableGrassPollutionGroundColor)}.{nameof(OnDisable)} instance of {nameof(TerrainManager)} does not exist");
#endif
                return false;
            }

            var properties = Singleton<TerrainManager>.instance?.m_properties;
            if (properties is null)
            {
#if DEV
                Log.Warning($"{nameof(DisableGrassPollutionGroundColor)}.{nameof(OnEnable)} instance of {nameof(TerrainProperties)} does not exist");
#endif
                return false;
            }

            Shader.SetGlobalVector(ShaderName, new Vector4(DefaultColorOffset.x, DefaultColorOffset.y, DefaultColorOffset.z, properties.m_cliffSandNormalTiling));
            return true;
        }

    }
}