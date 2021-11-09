using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal sealed class HideCliffDecorations : HideDecorations
    {
        public override FeatureKey Key => FeatureKey.HideCliffDecorations;

        public HideCliffDecorations(IModContext context) : base(context) { }

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
            properties.m_useCliffDecorations = !IsEnabled;
            return true;
        }
    }
}