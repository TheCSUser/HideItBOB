using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using System.IO;

namespace com.github.TheCSUser.HideItBobby.VersionMigrations
{
    using static File;

    internal class Migrate_1_28_1_to_1_29 : Migration
    {
        public Migrate_1_28_1_to_1_29(IModContext context) : base(context) { }

        public override void Migrate()
        {
            if (Mod.VersionFile?.Version >= 39) return;

            RemoveWithBackup(Paths.Translations.EN);

            if (Mod.VersionFile is null) Mod.VersionFile = new File_Version();
            Mod.VersionFile.Version = 30;
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