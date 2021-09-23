using com.github.TheCSUser.HideItBobby.Features;
using com.github.TheCSUser.HideItBobby.Features.Menu;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal sealed class MainMenuFeatures : FeaturesScript
    {
        #region Features
        private static IFeaturesContainer GetFeatures(IModContext context) => new FeaturesContainer(context)
            .Register(new HideMainMenuChirper(context))
            .Register(new HideMainMenuDLCPanel(context))
            .Register(new HideMainMenuLogo(context))
            .Register(new HideMainMenuNewsPanel(context))
            .Register(new HideMainMenuParadoxAccountPanel(context))
            .Register(new HideMainMenuVersionNumber(context))
            .Register(new HideMainMenuWorkshopPanel(context))
            ;
        #endregion
        #region Settings
        private static ISettingsContainer GetSettings(Mod mod)
        {
            return new SettingsContainer(mod.Context)
                .Register(FeatureKey.HideMainMenuChirper, () => mod.Settings.HideMainMenuChirper)
                .Register(FeatureKey.HideMainMenuDLCPanel, () => mod.Settings.HideMainMenuDLCPanel)
                .Register(FeatureKey.HideMainMenuLogo, () => mod.Settings.HideMainMenuLogo)
                .Register(FeatureKey.HideMainMenuNewsPanel, () => mod.Settings.HideMainMenuNewsPanel)
                .Register(FeatureKey.HideMainMenuParadoxAccountPanel, () => mod.Settings.HideMainMenuParadoxAccountPanel)
                .Register(FeatureKey.HideMainMenuVersionNumber, () => mod.Settings.HideMainMenuVersionNumber)
                .Register(FeatureKey.HideMainMenuWorkshopPanel, () => mod.Settings.HideMainMenuWorkshopPanel)
                ;
        }
        #endregion

        protected override string Name => $"{ModProperties.ShortName}.{nameof(MainMenuFeatures)}";

        public MainMenuFeatures(Mod mod) : base(mod, GetFeatures(mod.Context), GetSettings(mod)) { }
    }
}