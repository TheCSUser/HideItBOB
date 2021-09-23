using com.github.TheCSUser.Shared.Settings;
using System.Xml.Serialization;

namespace com.github.TheCSUser.HideItBobby.Settings.SettingsFiles
{
    [XmlType("ModVersionInfo")]
    public sealed class File_Version : SettingsFile
    {
        private int _version;
        [XmlElement("Version")]
        public int Version { get => _version; set => Set(ref _version, value, nameof(Version)); }
    }
}