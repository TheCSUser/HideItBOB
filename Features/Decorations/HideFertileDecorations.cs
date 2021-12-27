using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideFertileDecorations : HideDecorations
    {
        public override FeatureKey Key => FeatureKey.HideFertileDecorations;

        protected override bool PropertyValue
        {
            get => TerrainProperties.m_useFertileDecorations;
            set => TerrainProperties.m_useFertileDecorations = value;
        }

        public HideFertileDecorations(IModContext context) : base(context) { }
    }
}