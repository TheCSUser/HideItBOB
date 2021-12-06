using com.github.TheCSUser.HideItBobby.Scripts;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using System;
using System.IO;
using com.github.TheCSUser.HideItBobby.Localization;

namespace com.github.TheCSUser.HideItBobby
{
    using CurrentSettingsFile = File_1_21;

    public sealed partial class Mod : ModBase
    {
        internal new CurrentSettingsFile Settings => (CurrentSettingsFile)base.Settings;

        public override string Name => ModProperties.LongName;
        public override string Description => ModProperties.Description;

        public Mod() : base()
        {
            try
            {
                RegisterDependencies();

                UseLateInit();

                UseOnce(InitMigrations);

                UseLogger(Paths.Logs.Directory, ModProperties.LongName);
                Use(Migrate);
                Use(Context.Resolve<LocaleFilesManager>().Unpack);
                UseHarmony(ModProperties.HarmonyId);
                UseLocalization(Paths.Translations.Directory, FallbackLanguage.Build);
                UseSettings(new SettingsProvider(Context));
                Use(() =>
                {
                    if (Settings is null || Settings.UseGameLanguage) LocaleManager.ChangeToGameLanguage();
                    else LocaleManager.ChangeTo(Settings.SelectedLanguage);
                });

                UseMode(ApplicationMode.MainMenu)
                    .Add(Context.Resolve<MainMenuFeatures>());
                UseMode(ApplicationMode.Game)
                    .Add(Context.Resolve<InGameFeatures>());
            }
            catch (Exception e)
            {
                Shared.Logging.Log.Shared.Error($"{ModProperties.ShortName}.{nameof(Mod)}.Constructor failed", e);
                throw;
            }
        }
    }
}