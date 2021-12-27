using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideGrassDecorations : HideDecorations
    {
        public override FeatureKey Key => FeatureKey.HideGrassDecorations;

        protected override bool PropertyValue
        {
            get => TerrainProperties.m_useGrassDecorations;
            set => TerrainProperties.m_useGrassDecorations = value;
        }
        public HideGrassDecorations(IModContext context) : base(context) { }
    }
}