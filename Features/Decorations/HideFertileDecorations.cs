using ColossalFramework;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideFertileDecorations : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideFertileDecorations;

        public HideFertileDecorations(IModContext context) : base(context) { }

        protected override bool OnEnable()
        {
            if (!Singleton<TerrainManager>.exists) return false;

            Singleton<TerrainManager>.instance.m_properties.m_useFertileDecorations = false;
            return true;
        }
        protected override bool OnDisable()
        {
            if (!Singleton<TerrainManager>.exists) return false;

            Singleton<TerrainManager>.instance.m_properties.m_useFertileDecorations = true;
            return true;
        }
    }
}