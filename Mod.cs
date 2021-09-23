using com.github.TheCSUser.HideItBobby.Scripts;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.Providers;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.HideItBobby.Translation;
using com.github.TheCSUser.HideItBobby.VersionMigrations;
using com.github.TheCSUser.Shared.Common;
using System;
using System.IO;
using System.Collections.Generic;

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
            InitDependencies();
            InitMigrations();

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

        #region Version & Migrations
        private Provider_Version VersionProvider;
        private List<Migration> _migrations;
        internal File_Version VersionFile;

        private void InitMigrations()
        {
            VersionProvider = new Provider_Version(Context);

            _migrations = new List<Migration>
            {
                new Migrate_1_18_to_1_21(Context),
                new Migrate_1_20_to_1_21(Context),
                new Migrate_1_21_to_1_22(Context),
                new Migrate_1_24_to_1_25(Context),
            };
        }

        private void Migrate()
        {
            try
            {
                VersionFile = VersionProvider.Load();
                if (VersionFile is null || VersionFile.Version < ModProperties.VersionInteger)
                {
                    foreach (var migration in _migrations)
                    {
                        if (!(migration is null)) migration.Migrate();
                    }

                    VersionProvider.Save(VersionFile = new File_Version()
                    {
                        Version = ModProperties.VersionInteger
                    });
                }
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(Mod)}.{nameof(Migrate)} failed", e);
            }
        }
        #endregion

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