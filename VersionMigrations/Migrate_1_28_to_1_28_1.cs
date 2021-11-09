using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using System.IO;

namespace com.github.TheCSUser.HideItBobby.VersionMigrations
{
    using static File;

    internal class Migrate_1_28_to_1_28_1 : Migration
    {
        public Migrate_1_28_to_1_28_1(IModContext context) : base(context) { }

        public override void Migrate()
        {
            if (Mod.VersionFile?.Version >= 29) return;

            RemoveWithBackup(Paths.Translations.DE);
            RemoveWithBackup(Paths.Translations.EN);
            RemoveWithBackup(Paths.Translations.ES);
            RemoveWithBackup(Paths.Translations.JA);
            RemoveWithBackup(Paths.Translations.PL);
            RemoveWithBackup(Paths.Translations.RU);
            RemoveWithBackup(Paths.Translations.ZH);

            if (Mod.VersionFile is null) Mod.VersionFile = new File_Version();
            Mod.VersionFile.Version = 29;
        }

        private void RemoveWithBackup(string path)
        {
            var movePath = path + ".backup";
            if (Exists(path))
            {
                if (Exists(movePath)) Delete(movePath);
                Move(path, movePath);
            }
        }
    }
}