using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideCliffDecorations : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideCliffDecorations;
        private TerrainProperties TerrainProperties;

        public HideCliffDecorations(IModContext context) : base(context) { }

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

            TerrainProperties.m_useCliffDecorations = false;
            return true;
        }
        protected override bool OnDisable()
        {
            if (TerrainProperties is null) return false;

            TerrainProperties.m_useCliffDecorations = true;
            return true;
        }
    }
}