using com.github.TheCSUser.HideItBobby.Features.Menu;
using com.github.TheCSUser.HideItBobby.Properties;
using System;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal sealed class MainMenuFeatures : FeaturesScript
    {
        #region Features
        private static IFeaturesContainer GetFeatures(Mod mod)
        {
            try
            {
                return new FeaturesContainer(mod.Context)
                .Register(new HideMainMenuChirper(mod.Context), () => mod.Settings.HideMainMenuChirper)
                .Register(new HideMainMenuDLCPanel(mod.Context), () => mod.Settings.HideMainMenuDLCPanel)
                .Register(new HideMainMenuLogo(mod.Context), () => mod.Settings.HideMainMenuLogo)
                .Register(new HideMainMenuNewsPanel(mod.Context), () => mod.Settings.HideMainMenuNewsPanel)
                .Register(new HideMainMenuParadoxAccountPanel(mod.Context), () => mod.Settings.HideMainMenuParadoxAccountPanel)
                .Register(new HideMainMenuVersionNumber(mod.Context), () => mod.Settings.HideMainMenuVersionNumber)
                .Register(new HideMainMenuWorkshopPanel(mod.Context), () => mod.Settings.HideMainMenuWorkshopPanel)
                ;
            }
            catch (Exception e)
            {
                mod.Context.Log.Error($"{nameof(MainMenuFeatures)}.{nameof(GetFeatures)} failed", e);
                return FeaturesContainer.Empty;
            }
        }
        #endregion

        protected override string Name => $"{ModProperties.ShortName}.{nameof(MainMenuFeatures)}";

        public MainMenuFeatures(Mod mod) : base(mod, GetFeatures(mod)) { }
    }
}