#pragma warning disable 0649
using com.github.TheCSUser.Shared.Settings;
using System.Xml.Serialization;

namespace com.github.TheCSUser.HideItBobby.Settings.SettingsFiles
{
    [XmlType("ModConfig")]
    public sealed class File_1_19 : ReadOnlySettingsFile
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
    }
}
#pragma warning restore 0649