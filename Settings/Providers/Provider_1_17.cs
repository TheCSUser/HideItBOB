using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Settings;
using System;

namespace com.github.TheCSUser.HideItBobby.Settings.Providers
{
    internal sealed class Provider_1_17 : SettingsReaderWriter<File_1_17>
    {
        public override string FileName => Paths.Config.File_1_17;

        public Provider_1_17(IModContext context) : base(context) { }

        public override void Delete() => throw new InvalidOperationException($"{FileName} should not be deleted.");
    }
}