using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideCliffDecorations : HideDecorations
    {
        public override FeatureKey Key => FeatureKey.HideCliffDecorations;

        protected override bool PropertyValue
        {
            get => TerrainProperties.m_useCliffDecorations;
            set => TerrainProperties.m_useCliffDecorations = value;
        }

        public HideCliffDecorations(IModContext context) : base(context) { }
    }
}