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
                new Migrate_1_21_to_1_22(Context),
                new Migrate_1_24_to_1_25(Context),
                new Migrate_1_28_to_1_28_1(Context),
                new Migrate_1_28_1_to_1_29(Context),
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
    }
}