using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Settings;
using System;

namespace com.github.TheCSUser.HideItBobby.Settings.Providers
{
    internal sealed class Provider_Version : SettingsReaderWriter<File_Version>
    {
        public override string FileName => Paths.Config.VersionFile;

        public Provider_Version(IModContext context) : base(context) { }

        public override void Delete() => throw new InvalidOperationException($"{FileName} should not be deleted.");
    }
}