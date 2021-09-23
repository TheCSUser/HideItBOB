using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideFertileDecorations : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideFertileDecorations;
        private TerrainProperties TerrainProperties;

        public HideFertileDecorations(IModContext context) : base(context) { }

        protected override bool OnInitialize()
        {
            TerrainProperties = Object.FindObjectOfType<TerrainProperties>();
            return !(TerrainProperties is null);
        }
        protected override bool OnTerminate()
        {
            TerrainProperties = null;
            return true;
        }

        protected override bool OnEnable()
        {
            if (TerrainProperties is null) return false;

            TerrainProperties.m_useFertileDecorations = false;
            return true;
        }
        protected override bool OnDisable()
        {
            if (TerrainProperties is null) return false;

            TerrainProperties.m_useFertileDecorations = true;
            return true;
        }
    }
}