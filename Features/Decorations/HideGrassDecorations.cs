using ColossalFramework;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideGrassDecorations : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideGrassDecorations;
        
        public HideGrassDecorations(IModContext context) : base(context) { }

        protected override bool OnEnable()
        {
            if (!Singleton<TerrainManager>.exists) return false;

            Singleton<TerrainManager>.instance.m_properties.m_useGrassDecorations = false;
            return true;
        }
        protected override bool OnDisable()
        {
            if (!Singleton<TerrainManager>.exists) return false;

            Singleton<TerrainManager>.instance.m_properties.m_useGrassDecorations = true;
            return true;
        }
    }
}