using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using System.IO;
using System.Security.Cryptography;

namespace com.github.TheCSUser.HideItBobby.VersionMigrations
{
    using static File;
    using static Hash;

    internal class Migrate_1_24_to_1_25 : Migration
    {
        private const string HashValue = "12c13330511cb18972e566aafb37f85d566d67576fda04f383dc30cff6e3febb";

        public Migrate_1_24_to_1_25(IModContext context) : base(context) { }

        public override void Migrate()
        {
            if (Mod.VersionFile?.Version >= 25) return;

            var dePath = Paths.Translations.DE;
            if (Exists(dePath))
            {
                using (var sha256 = SHA256.Create())
                {
                    if (VerifyHash(sha256, dePath, HashValue)) Delete(dePath);
                }
            }

            var esPath = Paths.Translations.ES;
            var esMovePath = Path.Combine(Paths.Translations.Directory, "hide_it_bobby.es.xml.backup");
            if (Exists(esPath))
            {
                if (Exists(esMovePath)) Delete(esMovePath);
                Move(esPath, esMovePath);
            }

            if (Mod.VersionFile is null) Mod.VersionFile = new File_Version();
            Mod.VersionFile.Version = 25;
        }
    }
}