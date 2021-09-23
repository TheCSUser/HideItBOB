#pragma warning disable 0649
using com.github.TheCSUser.Shared.Settings;
using System.Xml.Serialization;

namespace com.github.TheCSUser.HideItBobby.Settings.SettingsFiles
{
    [XmlType("ModConfig")]
    public sealed class File_1_17 : ReadOnlySettingsFile
    {
        //Decorations
        [XmlElement("CliffDecorations")]
        public bool HideCliffDecorations;
        [XmlElement("FertileDecorations")]
        public bool HideFertileDecorations;
        [XmlElement("GrassDecorations")]
        public bool HideGrassDecorations;

        //Effects
        [XmlElement("OreArea")]
        public bool HideOreArea;
        [XmlElement("OilArea")]
        public bool HideOilArea;
        [XmlElement("SandArea")]
        public bool HideSandArea;
        [XmlElement("FertilityArea")]
        public bool HideFertilityArea;
        [XmlElement("ForestArea")]
        public bool HideForestArea;
        [XmlElement("ShoreArea")]
        public bool HideShoreArea;
        [XmlElement("PollutedArea")]
        public bool HidePollutedArea;
        [XmlElement("BurnedArea")]
        public bool HideBurnedArea;
        [XmlElement("DestroyedArea")]
        public bool HideDestroyedArea;
        [XmlElement("PollutionFog")]
        public bool HidePollutionFog;
        [XmlElement("VolumeFog")]
        public bool HideVolumeFog;
        [XmlElement("DistanceFog")]
        public bool HideDistanceFog;
        [XmlElement("EdgeFog")]
        public bool HideEdgeFog;

        //Ground and water color
        [XmlElement("GrassFertilityGroundColor")]
        public bool DisableGrassFertilityGroundColor;
        [XmlElement("GrassFieldGroundColor")]
        public bool DisableGrassFieldGroundColor;
        [XmlElement("GrassForestGroundColor")]
        public bool DisableGrassForestGroundColor;
        [XmlElement("GrassPollutionGroundColor")]
        public bool DisableGrassPollutionGroundColor;
        [XmlElement("DirtyWaterColor")]
        public bool DisableDirtyWaterColor;

        //Objects
        [XmlElement("Seagulls")]
        public bool HideSeagulls;
        [XmlElement("Wildlife")]
        public bool HideWildlife;

        //Ruining
        [XmlElement("TreeRuining")]
        public bool HideTreeRuining;
        [XmlElement("PropRuining")]
        public bool HidePropRuining;
        [XmlElement("AutoUpdateTreeRuiningAtLoad")]
        public bool AutoUpdateTreeRuiningAtLoad;
        [XmlElement("AutoUpdatePropRuiningAtLoad")]
        public bool AutoUpdatePropRuiningAtLoad;

        //In game ui elements
        [XmlElement("InfoViewsButton")]
        public bool HideInfoViewsButton;
        [XmlElement("DisastersButton")]
        public bool HideDisastersButton;
        [XmlElement("ChirperButton")]
        public bool HideChirperButton;
        [XmlElement("RadioButton")]
        public bool HideRadioButton;
        [XmlElement("GearButton")]
        public bool HideGearButton;
        [XmlElement("ZoomButton")]
        public bool HideZoomButton;
        [XmlElement("UnlockButton")]
        public bool HideUnlockButton;
        [XmlElement("AdvisorButton")]
        public bool HideAdvisorButton;
        [XmlElement("BulldozerButton")]
        public bool HideBulldozerButton;
        [XmlElement("CinematicCameraButton")]
        public bool HideCinematicCameraButton;
        [XmlElement("FreeCameraButton")]
        public bool HideFreeCameraButton;
        [XmlElement("CongratulationPanel")]
        public bool HideCongratulationPanel;
        [XmlElement("AdvisorPanel")]
        public bool HideAdvisorPanel;
        [XmlElement("TimePanel")]
        public bool HideTimePanel;
        [XmlElement("ZoomAndUnlockBackground")]
        public bool HideZoomAndUnlockBackground;
        [XmlElement("Separators")]
        public bool HideSeparators;

        //props
        [XmlElement("Flags")]
        public bool HideFlags;
        [XmlElement("Ads")]
        public bool HideAds;
        [XmlElement("Billboards")]
        public bool HideBillboards;
        [XmlElement("Neons")]
        public bool HideNeons;
        [XmlElement("Logos")]
        public bool HideLogos;
        [XmlElement("Smoke")]
        public bool HideSmoke;
        [XmlElement("Steam")]
        public bool HideSteam;
        [XmlElement("SolarPanels")]
        public bool HideSolarPanels;
        [XmlElement("HvacSystems")]
        public bool HideHvacSystems;
        [XmlElement("ParkingSpaces")]
        public bool HideParkingSpaces;
        [XmlElement("AbandonedAndDestroyedCars")]
        public bool HideAbandonedAndDestroyedCars;
        [XmlElement("CargoContainers")]
        public bool HideCargoContainers;
        [XmlElement("GarbageContainers")]
        public bool HideGarbageContainers;
        [XmlElement("GarbageBinsAndCans")]
        public bool HideGarbageBinsAndCans;
        [XmlElement("GarbagePiles")]
        public bool HideGarbagePiles;
        [XmlElement("Tanks")]
        public bool HideTanks;
        [XmlElement("Barrels")]
        public bool HideBarrels;
        [XmlElement("Pallets")]
        public bool HidePallets;
        [XmlElement("Crates")]
        public bool HideCrates;
        [XmlElement("Planks")]
        public bool HidePlanks;
        [XmlElement("CableReels")]
        public bool HideCableReels;
        [XmlElement("Hedges")]
        public bool HideHedges;
        [XmlElement("Fences")]
        public bool HideFences;
        [XmlElement("Gates")]
        public bool HideGates;
        [XmlElement("Mailboxes")]
        public bool HideMailboxes;
        [XmlElement("Chairs")]
        public bool HideChairs;
        [XmlElement("Tables")]
        public bool HideTables;
        [XmlElement("Parasols")]
        public bool HideParasols;
        [XmlElement("Grills")]
        public bool HideGrills;
        [XmlElement("Sandboxes")]
        public bool HideSandboxes;
        [XmlElement("Swings")]
        public bool HideSwings;
        [XmlElement("SwimmingPools")]
        public bool HideSwimmingPools;
        [XmlElement("PotsAndBeds")]
        public bool HidePotsAndBeds;
        [XmlElement("Delineators")]
        public bool HideDelineators;
        [XmlElement("RoadArrows")]
        public bool HideRoadArrows;
        [XmlElement("TramArrows")]
        public bool HideTramArrows;
        [XmlElement("BikeLanes")]
        public bool HideBikeLanes;
        [XmlElement("BusLanes")]
        public bool HideBusLanes;
        [XmlElement("Manholes")]
        public bool HideManholes;
        [XmlElement("BusStops")]
        public bool HideBusStops;
        [XmlElement("SightseeingBusStops")]
        public bool HideSightseeingBusStops;
        [XmlElement("TramStops")]
        public bool HideTramStops;
        [XmlElement("RailwayCrossings")]
        public bool HideRailwayCrossings;
        [XmlElement("StreetNameSigns")]
        public bool HideStreetNameSigns;
        [XmlElement("StopSigns")]
        public bool HideStopSigns;
        [XmlElement("TurnSigns")]
        public bool HideTurnSigns;
        [XmlElement("SpeedLimitSigns")]
        public bool HideSpeedLimitSigns;
        [XmlElement("NoParkingSigns")]
        public bool HideNoParkingSigns;
        [XmlElement("HighwaySigns")]
        public bool HideHighwaySigns;
        [XmlElement("PedestrianAndBikeStreetLights")]
        public bool HidePedestrianAndBikeStreetLights;
        [XmlElement("RoadStreetLights")]
        public bool HideRoadStreetLights;
        [XmlElement("AvenueStreetLights")]
        public bool HideAvenueStreetLights;
        [XmlElement("HighwayStreetLights")]
        public bool HideHighwayStreetLights;
        [XmlElement("RunwayLights")]
        public bool HideRunwayLights;
        [XmlElement("TaxiwayLights")]
        public bool HideTaxiwayLights;
        [XmlElement("WarningLights")]
        public bool HideWarningLights;
        [XmlElement("RandomStreetDecorations")]
        public bool HideRandomStreetDecorations;
        [XmlElement("Buoys")]
        public bool HideBuoys;
    }
}
#pragma warning restore 0649