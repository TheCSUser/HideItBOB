using com.github.TheCSUser.HideItBobby.Scripts;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.HideItBobby.Translation;
using com.github.TheCSUser.Shared.Common;
using System;
using System.IO;

namespace com.github.TheCSUser.HideItBobby
{
    using CurrentSettingsFile = File_1_21;

    public sealed partial class Mod : ModBase
    {
        internal new CurrentSettingsFile Settings => (CurrentSettingsFile)base.Settings;
        private readonly MainMenuFeatures MainMenuFeatures;
        private readonly InGameFeatures InGameFeatures;

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
                Use(UnpackLocaleFiles);
                UseHarmony(ModProperties.HarmonyId);
                UseLocalization(Paths.Translations.Directory, FallbackLanguage.Build);
                UseSettings(new SettingsProvider(Context));
                Use(() =>
                {
                    if (Settings is null || Settings.UseGameLanguage) LocaleManager.ChangeToGameLanguage();
                    else LocaleManager.ChangeTo(Settings.SelectedLanguage);
                });

                UseMode(ApplicationMode.MainMenu)
                    .Add(MainMenuFeatures = new MainMenuFeatures(this));
                UseMode(ApplicationMode.Game)
                    .Add(InGameFeatures = new InGameFeatures(this));
            }
            catch (Exception e)
            {
                Shared.Logging.Log.Shared.Error($"{ModProperties.ShortName}.{nameof(Mod)}.Constructor failed", e);
                throw;
            }
        }

        internal void UnpackLocaleFiles()
        {
            try
            {
                var dePath = Paths.Translations.DE;
                if (!File.Exists(dePath))
                {
                    File.WriteAllText(dePath, Resources.hide_it_bobby_de, System.Text.Encoding.UTF8);
                }

                var enPath = Paths.Translations.EN;
                if (!File.Exists(enPath))
                {
                    File.WriteAllText(enPath, Resources.hide_it_bobby_en, System.Text.Encoding.UTF8);
                }

                var esPath = Paths.Translations.ES;
                if (!File.Exists(esPath))
                {
                    File.WriteAllText(esPath, Resources.hide_it_bobby_es, System.Text.Encoding.UTF8);
                }

                var jaPath = Paths.Translations.JA;
                if (!File.Exists(jaPath))
                {
                    File.WriteAllText(jaPath, Resources.hide_it_bobby_ja, System.Text.Encoding.UTF8);
                }

                var plPath = Paths.Translations.PL;
                if (!File.Exists(plPath))
                {
                    File.WriteAllText(plPath, Resources.hide_it_bobby_pl, System.Text.Encoding.UTF8);
                }

                var ruPath = Paths.Translations.RU;
                if (!File.Exists(ruPath))
                {
                    File.WriteAllText(ruPath, Resources.hide_it_bobby_ru, System.Text.Encoding.UTF8);
                }

                var zhPath = Paths.Translations.ZH;
                if (!File.Exists(zhPath))
                {
                    File.WriteAllText(zhPath, Resources.hide_it_bobby_zh, System.Text.Encoding.UTF8);
                }
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(Mod)}.{nameof(UnpackLocaleFiles)} failed", e);
            }
        }
    }
}