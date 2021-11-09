using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideFertileDecorations : HideDecorations
    {
        public override FeatureKey Key => FeatureKey.HideFertileDecorations;

        public HideFertileDecorations(IModContext context) : base(context) { }

        protected override bool OnUpdate()
        {
            var properties = TerrainProperties;
            if (properties is null)
            {
#if DEV
                Log.Info($"{GetType().Name}.{nameof(OnUpdate)} {nameof(TerrainProperties)} is null");
#endif
                return false;
            }
            properties.m_useFertileDecorations = !IsEnabled;
            return true;
        }
    }
}