namespace com.github.TheCSUser.HideItBobby.Properties
{
    public static class ModProperties
    {
        public const string HarmonyId = "com.github.TheCSUser.HideItBobby";
        public const string Version = "1.30";
        public const int VersionInteger = 33;
        public const string Name = "Hide it, Bobby!";
        public const string ShortName = "HideItBobby";
#if DEV
        public const string Stream = "Dev";
        public const string LongName = Name + " " + Version + " " + Stream;
#elif PREVIEW
        public const string Stream = "Preview";
        public const string LongName = Name + " " + Version + " " + Stream;
#else
        public const string Stream = "";
        public const string LongName = Name + " " + Version;
#endif
        public const string Description = "BOB compatible fork of Hide It!.";
    }
}
