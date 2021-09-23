using ColossalFramework.IO;
using com.github.TheCSUser.Shared.Imports;
using com.github.TheCSUser.HideItBobby.Properties;
using System.IO;

namespace com.github.TheCSUser.HideItBobby.Settings
{
    using static Directory;
    using static Path;

    internal static class Paths
    {
        internal static class Logs
        {
            private static readonly Lazy<string> _logsDir = new Lazy<string>(() => {
                var path = Combine(Config.Directory, "Logs");
                if (!Exists(path)) CreateDirectory(path);
                return path;
            });
            public static string Directory => _logsDir.Value;
        }

        internal static class Config
        {
            private static readonly Lazy<string> _configDir = new Lazy<string>(() =>
            {
                var modsConfigPath = Combine(DataLocation.localApplicationData, "ModConfig");
                if (!Exists(modsConfigPath)) CreateDirectory(modsConfigPath);
                var path = Combine(modsConfigPath, ModProperties.ShortName);
                if (!Exists(path)) CreateDirectory(path);
                return path;
            });
            public static string Directory => _configDir.Value;

            private static readonly Lazy<string> _version = new Lazy<string>(() => Combine(Directory, "HideItBobbyVersion.xml"));
            public static string VersionFile => _version.Value;

            public static string File_1_17 => "HideItConfig.xml";

            public static string File_1_19 => "HideItBobbyConfig.xml";

            private static readonly Lazy<string> _1_21 = new Lazy<string>(() => Combine(Directory, "HideItBobbyConfig.xml"));
            public static string File_1_21 => _1_21.Value;

        }

        internal static class Translations
        {
            private static readonly Lazy<string> _translationsDir = new Lazy<string>(() =>
            {
                var path = Combine(Config.Directory, "Translations");
                if (!Exists(path)) CreateDirectory(path);
                return path;
            });
            public static string Directory => _translationsDir.Value;

            private static readonly Lazy<string> _de = new Lazy<string>(() => Combine(Directory, "hide_it_bobby.de.xml"));
            public static string DE => _de.Value;

            private static readonly Lazy<string> _en = new Lazy<string>(() => Combine(Directory, "hide_it_bobby.en.xml"));
            public static string EN => _en.Value;

            private static readonly Lazy<string> _es = new Lazy<string>(() => Combine(Directory, "hide_it_bobby.es.xml"));
            public static string ES => _es.Value;

            private static readonly Lazy<string> _ja = new Lazy<string>(() => Combine(Directory, "hide_it_bobby.ja.xml"));
            public static string JA => _ja.Value;

            private static readonly Lazy<string> _pl = new Lazy<string>(() => Combine(Directory, "hide_it_bobby.pl.xml"));
            public static string PL => _pl.Value;

            private static readonly Lazy<string> _ru = new Lazy<string>(() => Combine(Directory, "hide_it_bobby.ru.xml"));
            public static string RU => _ru.Value;

            private static readonly Lazy<string> _zh = new Lazy<string>(() => Combine(Directory, "hide_it_bobby.zh.xml"));
            public static string ZH => _zh.Value;
        }
    }
}
