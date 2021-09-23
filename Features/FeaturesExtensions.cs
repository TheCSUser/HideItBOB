namespace com.github.TheCSUser.HideItBobby.Features
{
    internal static class FeaturesExtensions
    {
        public static FeatureFlags Set(this IFeature feature, bool enable)
        {
            if (feature is null) return FeatureFlags.False;
            if (enable)
            {
                if (feature is IFeature toggleable && !toggleable.IsEnabled) return toggleable.Enable();
                if (feature is IUpdatableFeature updateable) return updateable.Update();
            }
            else
            {
                if (feature is IFeature toggleable && toggleable.IsEnabled) return toggleable.Disable();
            }
            return FeatureFlags.True;
        }

        public static FeatureFlags Run(this IFeature feature)
        {
            if (feature is null) return FeatureFlags.False;
            if (feature is IFeature toDisable && !toDisable.IsEnabled) return toDisable.Disable(true);
            if (feature is IUpdatableFeature toUpdate) return toUpdate.Update();
            if (feature is IFeature toEnable) return toEnable.Enable(true);
            return FeatureFlags.True;
        }
    }
}