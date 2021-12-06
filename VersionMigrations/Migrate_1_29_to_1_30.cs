using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using System.IO;

namespace com.github.TheCSUser.HideItBobby.VersionMigrations
{
    using static File;

    internal class Migrate_1_29_to_1_30 : Migration
    {
        public Migrate_1_29_to_1_30(IModContext context) : base(context) { }

        public override void Migrate()
        {
            if (Mod.VersionFile?.Version >= 31) return;

            foreach (var file in new[]
            {
                Paths.Translations.DE+".backup",
                Paths.Translations.EN+".backup",
                Paths.Translations.ES+".backup",
                Paths.Translations.JA+".backup",
                Paths.Translations.PL+".backup",
                Paths.Translations.RU+".backup",
                Paths.Translations.ZH+".backup"
            })
            {
                if (Exists(file)) Delete(file);
            }

            if (Mod.VersionFile is null) Mod.VersionFile = new File_Version();
            Mod.VersionFile.Version = 31;
        }
    }
}