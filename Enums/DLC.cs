using com.github.TheCSUser.Shared.Imports;
using System;

namespace com.github.TheCSUser.HideItBobby.Enums
{
    ///<completionlist cref="DLC"/>
    internal sealed class DLC : StringEnum<DLC>
    {
        public static readonly DLC AfterDark = Create("AfterDarkDLC");
        public static readonly DLC Snowfall = Create("SnowFallDLC");
        public static readonly DLC NaturalDisasters = Create("NaturalDisastersDLC");
        public static readonly DLC MassTransit = Create("InMotionDLC");
        public static readonly DLC GreenCities = Create("GreenCitiesDLC");
        public static readonly DLC Concerts = Create("MusicFestival");
        public static readonly DLC ParkLife = Create("ParksDLC");
        public static readonly DLC Industries = Create("IndustryDLC");
        public static readonly DLC Campus = Create("CampusDLC");
        public static readonly DLC SunsetHarbor = Create("UrbanDLC");
        //public static readonly DLC Airports = Create();

        public static implicit operator SteamHelper.DLC(DLC dlc) => (SteamHelper.DLC)Enum.Parse(typeof(SteamHelper.DLC), dlc.Value);
    }
}