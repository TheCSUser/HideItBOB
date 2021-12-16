using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Imports;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace com.github.TheCSUser.HideItBobby.Localization
{
    using static Hash;
    using static Path;
    using static Resources;
    using static ResourcesSHA;

    [SuppressMessage("Style", "IDE0071:Simplify interpolation", Justification = "Personal preference")]
    internal sealed class LocaleFilesManager : WithContext
    {
        private static readonly Encoding UTF8WithoutBOMEncoding = new UTF8Encoding(false);

        private static readonly Lazy<HashSet<string>> _knownHashes = new Lazy<HashSet<string>>(() => new HashSet<string>
            {
               hide_it_bobby_21_BOM_en_sha256,
               hide_it_bobby_21_en_sha256,
               hide_it_bobby_21_BOM_pl_sha256,
               hide_it_bobby_21_pl_sha256,
               hide_it_bobby_22_BOM_de_sha256,
               hide_it_bobby_22_de_sha256,
               hide_it_bobby_22_BOM_pl_sha256,
               hide_it_bobby_22_pl_sha256,
               hide_it_bobby_22_BOM_zh_sha256,
               hide_it_bobby_22_zh_sha256,
               hide_it_bobby_23_BOM_ja_sha256,
               hide_it_bobby_23_ja_sha256,
               hide_it_bobby_25_BOM_de_sha256,
               hide_it_bobby_25_de_sha256,
               hide_it_bobby_25_BOM_es_sha256,
               hide_it_bobby_25_es_sha256,
               hide_it_bobby_29_BOM_de_sha256,
               hide_it_bobby_29_de_sha256,
               hide_it_bobby_29_BOM_en_sha256,
               hide_it_bobby_29_en_sha256,
               hide_it_bobby_29_BOM_es_sha256,
               hide_it_bobby_29_es_sha256,
               hide_it_bobby_29_BOM_ja_sha256,
               hide_it_bobby_29_ja_sha256,
               hide_it_bobby_29_BOM_pl_sha256,
               hide_it_bobby_29_pl_sha256,
               hide_it_bobby_29_BOM_ru_sha256,
               hide_it_bobby_29_ru_sha256,
               hide_it_bobby_29_BOM_zh_sha256,
               hide_it_bobby_29_zh_sha256,
               hide_it_bobby_30_BOM_en_sha256,
               hide_it_bobby_30_en_sha256,
               hide_it_bobby_31_ja_sha256,
               hide_it_bobby_31_ko_sha256,
               hide_it_bobby_31_en_sha256,
               hide_it_bobby_32_ja_sha256,
               hide_it_bobby_33_pt_sha256,
               hide_it_bobby_33_ru_sha256,
               hide_it_bobby_34_de_sha256,
               hide_it_bobby_34_en_sha256,
               hide_it_bobby_34_es_sha256,
               hide_it_bobby_34_ja_sha256,
               hide_it_bobby_34_ko_sha256,
               hide_it_bobby_34_pl_sha256,
               hide_it_bobby_34_pt_sha256,
               hide_it_bobby_34_ru_sha256,
               hide_it_bobby_34_zh_sha256
            });
        private static readonly Lazy<Dictionary<string, string>> _keyToHash = new Lazy<Dictionary<string, string>>(() => new Dictionary<string, string>
            {
                { "de", hide_it_bobby_34_de_sha256 },
                { "en", hide_it_bobby_34_en_sha256 },
                { "es", hide_it_bobby_34_es_sha256 },
                { "ja", hide_it_bobby_34_ja_sha256 },
                { "ko", hide_it_bobby_34_ko_sha256 },
                { "pl", hide_it_bobby_34_pl_sha256 },
                { "pt", hide_it_bobby_34_pt_sha256 },
                { "ru", hide_it_bobby_34_ru_sha256 },
                { "zh", hide_it_bobby_34_zh_sha256 },
            });
        private static readonly Lazy<ReadOnlyCollection<FileInfo>> _files = new Lazy<ReadOnlyCollection<FileInfo>>(() => new List<FileInfo>
            {
                new FileInfo("de", Paths.Translations.DE, hide_it_bobby_de),
                new FileInfo("en", Paths.Translations.EN, hide_it_bobby_en),
                new FileInfo("es", Paths.Translations.ES, hide_it_bobby_es),
                new FileInfo("ja", Paths.Translations.JA, hide_it_bobby_ja),
                new FileInfo("ko", Paths.Translations.KO, hide_it_bobby_ko),
                new FileInfo("pl", Paths.Translations.PL, hide_it_bobby_pl),
                new FileInfo("pt", Paths.Translations.PT, hide_it_bobby_pt),
                new FileInfo("ru", Paths.Translations.RU, hide_it_bobby_ru),
                new FileInfo("zh", Paths.Translations.ZH, hide_it_bobby_zh),
            }.AsReadOnly());
        public ReadOnlyCollection<FileInfo> Files => _files.Value;

        public LocaleFilesManager(IModContext context) : base(context) { }

        public void Unpack() => Unpack(false);
        public void Unpack(bool overrite)
        {
            try
            {
                foreach (var file in Files)
                {
                    if (file.Exists())
                    {
                        if (overrite) file.Delete();
                        else continue;
                    }
                    file.Unpack();
                }
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(LocaleFilesManager)}.{nameof(Unpack)} failed", e);
            }
        }

        public sealed class FileInfo
        {
            private readonly string _resourceContent;


            public string Name => GetFileName(Path);
            public string Path { get; private set; }
            public string LanguageKey { get; private set; }

            public FileInfo(string key, string path, string resourceContent)
            {
                LanguageKey = key;
                Path = path;
                _resourceContent = resourceContent;
            }

            public HashInfo GetHashInfo()
            {
                string hash;
                using (SHA256 sha256 = SHA256.Create()) hash = GetHash(sha256, Path);
                if (hash is null)
                {
                    return new HashInfo(null, false, false);
                }
                return new HashInfo(
                    hash,
                    _keyToHash.Value.TryGetValue(LanguageKey, out var latestHash) && latestHash == hash,
                    _knownHashes.Value.Contains(hash)
                );
            }

            public bool Exists() => File.Exists(Path);
            public void Delete() => File.Delete(Path);

            public void Backup()
            {
                var backupPath = Combine(GetDirectoryName(Path), $"{DateTime.Now.ToString("yyyyMMdd_HHmm")}.{GetFileName(Path)}.bak");
                if (File.Exists(Path))
                {
                    if (File.Exists(backupPath)) File.Delete(backupPath);
                    File.Copy(Path, backupPath);
                }
            }

            public void Unpack() => File.WriteAllText(Path, _resourceContent, UTF8WithoutBOMEncoding);
        }

        public struct HashInfo
        {
            public string Hash;

            public bool IsLatest;
            public bool IsKnown;

            public HashInfo(string hash, bool isLatest, bool isKnown)
            {
                Hash = hash;
                IsLatest = isLatest;
                IsKnown = isKnown;
            }
        }
    }
}
