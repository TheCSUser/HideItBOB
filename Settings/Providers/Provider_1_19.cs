using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Settings;

namespace com.github.TheCSUser.HideItBobby.Settings.Providers
{
    internal sealed class Provider_1_19 : SettingsReaderWriter<File_1_19>
    {
        public override string FileName => Paths.Config.File_1_19;

        public Provider_1_19(IModContext context) : base(context) { }
    }
}