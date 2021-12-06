using com.github.TheCSUser.HideItBobby.Localization;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.HideItBobby.Settings.Providers;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.HideItBobby.VersionMigrations;
using System;
using System.Collections.Generic;

namespace com.github.TheCSUser.HideItBobby
{
    public sealed partial class Mod
    {
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
                new Migrate_1_29_to_1_30(Context),
            };
        }

        private void Migrate()
        {
            try
            {
                VersionFile = VersionProvider.Load();
                if (VersionFile is null || VersionFile.Version < ModProperties.VersionInteger)
                {
                    RunMigrations();
                    UpdateLocaleFiles();

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

        private void RunMigrations()
        {
            try
            {
                foreach (var migration in _migrations)
                {
                    if (!(migration is null)) migration.Migrate();
                }
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(Mod)}.{nameof(RunMigrations)} failed", e);
            }
        }

        private void UpdateLocaleFiles()
        {
            var manager = Context.Resolve<LocaleFilesManager>();
#if DEV
            foreach (var file in manager.Files)
            { 
                var info = file.GetHashInfo();
                Log.Info($"{file.Name} SHA256: {info.Hash} IsKnown: {info.IsKnown} IsLatest: {info.IsLatest}");
            }
#endif
            foreach (var file in manager.Files)
            {
#if DEV
                Log.Info($"{nameof(Mod)}.{nameof(UpdateLocaleFiles)} updating file {file.Name}");
#endif
                try
                {
                    if (!file.Exists())
                    {
#if DEV
                        Log.Info($"{nameof(Mod)}.{nameof(UpdateLocaleFiles)} {file.Name} does not exist. Unpacking.");
#endif
                        file.Unpack();
                        continue;
                    }

                    var info = file.GetHashInfo();
                    if (info.IsLatest)
                    {
#if DEV
                        Log.Info($"{nameof(Mod)}.{nameof(UpdateLocaleFiles)} {file.Name} is already in the latest version.");
#endif
                        continue;
                    }

                    if (!info.IsKnown)
                    {
#if DEV
                        Log.Info($"{nameof(Mod)}.{nameof(UpdateLocaleFiles)} {file.Name} not known. Backing up.");
#endif
                        file.Backup();
                    }
                    file.Delete();
#if DEV
                    Log.Info($"{nameof(Mod)}.{nameof(UpdateLocaleFiles)} updating {file.Name} to the latest version.");
#endif
                    file.Unpack();
                }
                catch (Exception e)
                {
                    Log.Error($"{nameof(Mod)}.{nameof(UpdateLocaleFiles)} failed to process file {file.Name}", e);
                }
            }
        }
    }
}