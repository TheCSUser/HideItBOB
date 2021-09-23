using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using System.IO;
using System.Security.Cryptography;

namespace com.github.TheCSUser.HideItBobby.VersionMigrations
{
    internal class Migrate_1_21_to_1_22 : Migration
    {
        private const string HashValue = "f29d85c675c5666194d388d11b89834dc08bfd5a66d80df25c8cab5d2c58e8f1";

        public Migrate_1_21_to_1_22(IModContext context) : base(context) { }

        public override void Migrate()
        {
            if (Mod.VersionFile?.Version >= 22) return;

            var plPath = Paths.Translations.PL;
            if (!File.Exists(plPath)) return;

            using (SHA256 sha256 = SHA256.Create())
            {
                if (Hash.VerifyHash(sha256, plPath, HashValue)) File.Delete(plPath);
            }

            if (Mod.VersionFile is null) Mod.VersionFile = new File_Version();
            Mod.VersionFile.Version = 22;
        }
    }
}