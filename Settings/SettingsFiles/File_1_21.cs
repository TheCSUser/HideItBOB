using com.github.TheCSUser.Shared.Settings;
using System.Xml.Serialization;

namespace com.github.TheCSUser.HideItBobby.Settings.SettingsFiles
{
    [XmlType("ModConfig")]
    public sealed class File_1_21 : SettingsFile
    {
        #region Language
        private bool _useGameLanguage = true;
        [XmlElement("UseGameLanguage")]
        public bool UseGameLanguage { get => _useGameLanguage; set => Set(ref _useGameLanguage, value, nameof(UseGameLanguage)); }

        private string _selectedLanguage;
        [XmlElement("SelectedLanguage")]
        public string SelectedLanguage { get => _selectedLanguage; set => Set(ref _selectedLanguage, value, nameof(SelectedLanguage)); }
        #endregion

        #region Main menu features
        private bool _hideMainMenuChirper;
        [XmlElement("HideMainMenuChirper")]
        public bool HideMainMenuChirper { get => _hideMainMenuChirper; set => Set(ref _hideMainMenuChirper, value, nameof(HideMainMenuChirper)); }

        private bool _hideMainMenuDLCPanel;
        [XmlElement("HideMainMenuDLCPanel")]
        public bool HideMainMenuDLCPanel { get => _hideMainMenuDLCPanel; set => Set(ref _hideMainMenuDLCPanel, value, nameof(HideMainMenuDLCPanel)); }

        private bool _hideMainMenuLogo;
        [XmlElement("HideMainMenuLogo")]
        public bool HideMainMenuLogo { get => _hideMainMenuLogo; set => Set(ref _hideMainMenuLogo, value, nameof(HideMainMenuLogo)); }

        private bool _hideMainMenuNewsPanel;
        [XmlElement("HideMainMenuNewsPanel")]
        public bool HideMainMenuNewsPanel { get => _hideMainMenuNewsPanel; set => Set(ref _hideMainMenuNewsPanel, value, nameof(HideMainMenuNewsPanel)); }

        private bool _hideMainMenuParadoxAccountPanel;
        [XmlElement("HideMainMenuParadoxAccountPanel")]
        public bool HideMainMenuParadoxAccountPanel { get => _hideMainMenuParadoxAccountPanel; set => Set(ref _hideMainMenuParadoxAccountPanel, value, nameof(HideMainMenuParadoxAccountPanel)); }

        private bool _hideMainMenuVersionNumber;
        [XmlElement("HideMainMenuVersionNumber")]
        public bool HideMainMenuVersionNumber { get => _hideMainMenuVersionNumber; set => Set(ref _hideMainMenuVersionNumber, value, nameof(HideMainMenuVersionNumber)); }

        private bool _hideMainMenuWorkshopPanel;
        [XmlElement("HideMainMenuWorkshopPanel")]
        public bool HideMainMenuWorkshopPanel { get => _hideMainMenuWorkshopPanel; set => Set(ref _hideMainMenuWorkshopPanel, value, nameof(HideMainMenuWorkshopPanel)); }
        #endregion

        #region In game features
        //Decorations
        private bool _overrideThemeMixer2;
        [XmlElement("OverrideThemeMixer2")]
        public bool OverrideThemeMixer2 { get => _overrideThemeMixer2; set => Set(ref _overrideThemeMixer2, value, nameof(OverrideThemeMixer2)); }

        private bool _hideCliffDecorations;
        [XmlElement("HideCliffDecorations")]
        public bool HideCliffDecorations { get => _hideCliffDecorations; set => Set(ref _hideCliffDecorations, value, nameof(HideCliffDecorations)); }

        private bool _hideFertileDecorations;
        [XmlElement("HideFertileDecorations")]
        public bool HideFertileDecorations { get => _hideFertileDecorations; set => Set(ref _hideFertileDecorations, value, nameof(HideFertileDecorations)); }

        private bool _hideGrassDecorations;
        [XmlElement("HideGrassDecorations")]
        public bool HideGrassDecorations { get => _hideGrassDecorations; set => Set(ref _hideGrassDecorations, value, nameof(HideGrassDecorations)); }

        //Effects
        private bool _hideOreArea;
        [XmlElement("HideOreArea")]
        public bool HideOreArea { get => _hideOreArea; set => Set(ref _hideOreArea, value, nameof(HideOreArea)); }

        private bool _hideOilArea;
        [XmlElement("HideOilArea")]
        public bool HideOilArea { get => _hideOilArea; set => Set(ref _hideOilArea, value, nameof(HideOilArea)); }

        private bool _hideSandArea;
        [XmlElement("HideSandArea")]
        public bool HideSandArea { get => _hideSandArea; set => Set(ref _hideSandArea, value, nameof(HideSandArea)); }

        private bool _hideFertilityArea;
        [XmlElement("HideFertilityArea")]
        public bool HideFertilityArea { get => _hideFertilityArea; set => Set(ref _hideFertilityArea, value, nameof(HideFertilityArea)); }

        private bool _hideForestArea;
        [XmlElement("HideForestArea")]
        public bool HideForestArea { get => _hideForestArea; set => Set(ref _hideForestArea, value, nameof(HideForestArea)); }

        private bool _hideShoreArea;
        [XmlElement("HideShoreArea")]
        public bool HideShoreArea { get => _hideShoreArea; set => Set(ref _hideShoreArea, value, nameof(HideShoreArea)); }

        private bool _hidePollutedArea;
        [XmlElement("HidePollutedArea")]
        public bool HidePollutedArea { get => _hidePollutedArea; set => Set(ref _hidePollutedArea, value, nameof(HidePollutedArea)); }

        private bool _hideBurnedArea;
        [XmlElement("HideBurnedArea")]
        public bool HideBurnedArea { get => _hideBurnedArea; set => Set(ref _hideBurnedArea, value, nameof(HideBurnedArea)); }

        private bool _hideDestroyedArea;
        [XmlElement("HideDestroyedArea")]
        public bool HideDestroyedArea { get => _hideDestroyedArea; set => Set(ref _hideDestroyedArea, value, nameof(HideDestroyedArea)); }

        private bool _hidePollutionFog;
        [XmlElement("HidePollutionFog")]
        public bool HidePollutionFog { get => _hidePollutionFog; set => Set(ref _hidePollutionFog, value, nameof(HidePollutionFog)); }

        private bool _hideVolumeFog;
        [XmlElement("HideVolumeFog")]
        public bool HideVolumeFog { get => _hideVolumeFog; set => Set(ref _hideVolumeFog, value, nameof(HideVolumeFog)); }

        private bool _hideDistanceFog;
        [XmlElement("HideDistanceFog")]
        public bool HideDistanceFog { get => _hideDistanceFog; set => Set(ref _hideDistanceFog, value, nameof(HideDistanceFog)); }

        private bool _hideEdgeFog;
        [XmlElement("HideEdgeFog")]
        public bool HideEdgeFog { get => _hideEdgeFog; set => Set(ref _hideEdgeFog, value, nameof(HideEdgeFog)); }

        private bool _disablePlacementEffect;
        [XmlElement("DisablePlacementEffect")]
        public bool DisablePlacementEffect { get => _disablePlacementEffect; set => Set(ref _disablePlacementEffect, value, nameof(DisablePlacementEffect)); }

        private bool _disableBulldozingEffect;
        [XmlElement("DisableBulldozingEffect")]
        public bool DisableBulldozingEffect { get => _disableBulldozingEffect; set => Set(ref _disableBulldozingEffect, value, nameof(DisableBulldozingEffect)); }

        //Ground and water color
        private bool _disableGrassFertilityGroundColor;
        [XmlElement("DisableGrassFertilityGroundColor")]
        public bool DisableGrassFertilityGroundColor { get => _disableGrassFertilityGroundColor; set => Set(ref _disableGrassFertilityGroundColor, value, nameof(DisableGrassFertilityGroundColor)); }

        private bool _disableGrassFieldGroundColor;
        [XmlElement("DisableGrassFieldGroundColor")]
        public bool DisableGrassFieldGroundColor { get => _disableGrassFieldGroundColor; set => Set(ref _disableGrassFieldGroundColor, value, nameof(DisableGrassFieldGroundColor)); }

        private bool _disableGrassForestGroundColor;
        [XmlElement("DisableGrassForestGroundColor")]
        public bool DisableGrassForestGroundColor { get => _disableGrassForestGroundColor; set => Set(ref _disableGrassForestGroundColor, value, nameof(DisableGrassForestGroundColor)); }

        private bool _disableGrassPollutionGroundColor;
        [XmlElement("DisableGrassPollutionGroundColor")]
        public bool DisableGrassPollutionGroundColor { get => _disableGrassPollutionGroundColor; set => Set(ref _disableGrassPollutionGroundColor, value, nameof(DisableGrassPollutionGroundColor)); }

        private bool _disableDirtyWaterColor;
        [XmlElement("DisableDirtyWaterColor")]
        public bool DisableDirtyWaterColor { get => _disableDirtyWaterColor; set => Set(ref _disableDirtyWaterColor, value, nameof(DisableDirtyWaterColor)); }

        //Objects
        private bool _hideSeagulls;
        [XmlElement("HideSeagulls")]
        public bool HideSeagulls { get => _hideSeagulls; set => Set(ref _hideSeagulls, value, nameof(HideSeagulls)); }

        private bool _hideWildlife;
        [XmlElement("HideWildlife")]
        public bool HideWildlife { get => _hideWildlife; set => Set(ref _hideWildlife, value, nameof(HideWildlife)); }

        //Ruining - Deprecated
        private bool _hideTreeRuining;
        [XmlElement("HideTreeRuining")]
        public bool HideTreeRuining { get => _hideTreeRuining; set => Set(ref _hideTreeRuining, value, nameof(HideTreeRuining)); }

        private bool _hidePropRuining;
        [XmlElement("HidePropRuining")]
        public bool HidePropRuining { get => _hidePropRuining; set => Set(ref _hidePropRuining, value, nameof(HidePropRuining)); }

        //In game ui elements
        private bool _hideInfoViewsButton;
        [XmlElement("HideInfoViewsButton")]
        public bool HideInfoViewsButton { get => _hideInfoViewsButton; set => Set(ref _hideInfoViewsButton, value, nameof(HideInfoViewsButton)); }

        private bool _hideDisastersButton;
        [XmlElement("HideDisastersButton")]
        public bool HideDisastersButton { get => _hideDisastersButton; set => Set(ref _hideDisastersButton, value, nameof(HideDisastersButton)); }

        private bool _hideChirperButton;
        [XmlElement("HideChirperButton")]
        public bool HideChirperButton { get => _hideChirperButton; set => Set(ref _hideChirperButton, value, nameof(HideChirperButton)); }

        private bool _hideRadioButton;
        [XmlElement("HideRadioButton")]
        public bool HideRadioButton { get => _hideRadioButton; set => Set(ref _hideRadioButton, value, nameof(HideRadioButton)); }

        private bool _hideGearButton;
        [XmlElement("HideGearButton")]
        public bool HideGearButton { get => _hideGearButton; set => Set(ref _hideGearButton, value, nameof(HideGearButton)); }

        private bool _hideZoomButton;
        [XmlElement("HideZoomButton")]
        public bool HideZoomButton { get => _hideZoomButton; set => Set(ref _hideZoomButton, value, nameof(HideZoomButton)); }

        private bool _hideUnlockButton;
        [XmlElement("HideUnlockButton")]
        public bool HideUnlockButton { get => _hideUnlockButton; set => Set(ref _hideUnlockButton, value, nameof(HideUnlockButton)); }

        private bool _hideAdvisorButton;
        [XmlElement("HideAdvisorButton")]
        public bool HideAdvisorButton { get => _hideAdvisorButton; set => Set(ref _hideAdvisorButton, value, nameof(HideAdvisorButton)); }

        private bool _hideBulldozerButton;
        [XmlElement("HideBulldozerButton")]
        public bool HideBulldozerButton { get => _hideBulldozerButton; set => Set(ref _hideBulldozerButton, value, nameof(HideBulldozerButton)); }

        private bool _hideCinematicCameraButton;
        [XmlElement("HideCinematicCameraButton")]
        public bool HideCinematicCameraButton { get => _hideCinematicCameraButton; set => Set(ref _hideCinematicCameraButton, value, nameof(HideCinematicCameraButton)); }

        private bool _hideFreeCameraButton;
        [XmlElement("HideFreeCameraButton")]
        public bool HideFreeCameraButton { get => _hideFreeCameraButton; set => Set(ref _hideFreeCameraButton, value, nameof(HideFreeCameraButton)); }

        private bool _hideCongratulationPanel;
        [XmlElement("HideCongratulationPanel")]
        public bool HideCongratulationPanel { get => _hideCongratulationPanel; set => Set(ref _hideCongratulationPanel, value, nameof(HideCongratulationPanel)); }

        private bool _hideAdvisorPanel;
        [XmlElement("HideAdvisorPanel")]
        public bool HideAdvisorPanel { get => _hideAdvisorPanel; set => Set(ref _hideAdvisorPanel, value, nameof(HideAdvisorPanel)); }

        private bool _hideTimePanel;
        [XmlElement("HideTimePanel")]
        public bool HideTimePanel { get => _hideTimePanel; set => Set(ref _hideTimePanel, value, nameof(HideTimePanel)); }

        private bool _hideZoomAndUnlockBackground;
        [XmlElement("HideZoomAndUnlockBackground")]
        public bool HideZoomAndUnlockBackground { get => _hideZoomAndUnlockBackground; set => Set(ref _hideZoomAndUnlockBackground, value, nameof(HideZoomAndUnlockBackground)); }

        private bool _hideSeparators;
        [XmlElement("HideSeparators")]
        public bool HideSeparators { get => _hideSeparators; set => Set(ref _hideSeparators, value, nameof(HideSeparators)); }

        private bool _hideCityName;
        [XmlElement("HideCityName")]
        public bool HideCityName { get => _hideCityName; set => Set(ref _hideCityName, value, nameof(HideCityName)); }

        private bool _modifyCityNamePosition;
        [XmlElement("ModifyCityNamePosition")]
        public bool ModifyCityNamePosition { get => _modifyCityNamePosition; set => Set(ref _modifyCityNamePosition, value, nameof(ModifyCityNamePosition)); }

        private float _cityNamePosition;
        [XmlElement("CityNamePosition")]
        public float CityNamePosition { get => _cityNamePosition; set => Set(ref _cityNamePosition, value, nameof(CityNamePosition)); }

        private bool _hidePauseOutline;
        [XmlElement("HidePauseOutline")]
        public bool HidePauseOutline { get => _hidePauseOutline; set => Set(ref _hidePauseOutline, value, nameof(HidePauseOutline)); }

        private bool _hideBulldozerBar;
        [XmlElement("HideBulldozerBar")]
        public bool HideBulldozerBar { get => _hideBulldozerBar; set => Set(ref _hideBulldozerBar, value, nameof(HideBulldozerBar)); }

        private bool _hideThermometer;
        [XmlElement("HideThermometer")]
        public bool HideThermometer { get => _hideThermometer; set => Set(ref _hideThermometer, value, nameof(HideThermometer)); }

        private bool _modifyToolbarPosition;
        [XmlElement("ModifyToolbarPosition")]
        public bool ModifyToolbarPosition { get => _modifyToolbarPosition; set => Set(ref _modifyToolbarPosition, value, nameof(ModifyToolbarPosition)); }

        private float _toolbarPosition;
        [XmlElement("ToolbarPosition")]
        public float ToolbarPosition { get => _toolbarPosition; set => Set(ref _toolbarPosition, value, nameof(ToolbarPosition)); }

        private bool _hideNetworksCursorInfo;
        [XmlElement("HideNetworksCursorInfo")]
        public bool HideNetworksCursorInfo { get => _hideNetworksCursorInfo; set => Set(ref _hideNetworksCursorInfo, value, nameof(HideNetworksCursorInfo)); }

        private bool _hideBuildingsCursorInfo;
        [XmlElement("HideBuildingsCursorInfo")]
        public bool HideBuildingsCursorInfo { get => _hideBuildingsCursorInfo; set => Set(ref _hideBuildingsCursorInfo, value, nameof(HideBuildingsCursorInfo)); }

        private bool _hideTreesCursorInfo;
        [XmlElement("HideTreesCursorInfo")]
        public bool HideTreesCursorInfo { get => _hideTreesCursorInfo; set => Set(ref _hideTreesCursorInfo, value, nameof(HideTreesCursorInfo)); }

        private bool _hidePropsCursorInfo;
        [XmlElement("HidePropsCursorInfo")]
        public bool HidePropsCursorInfo { get => _hidePropsCursorInfo; set => Set(ref _hidePropsCursorInfo, value, nameof(HidePropsCursorInfo)); }

        //problems
        private bool _hideTerraformNetworkFloodNotification;
        [XmlElement("HideTerraformNetworkFloodNotification")]
        public bool HideTerraformNetworkFloodNotification { get => _hideTerraformNetworkFloodNotification; set => Set(ref _hideTerraformNetworkFloodNotification, value, nameof(HideTerraformNetworkFloodNotification)); }

        private bool _hideDisconnectedPowerLinesNotification;
        [XmlElement("HideDisconnectedPowerLinesNotification")]
        public bool HideDisconnectedPowerLinesNotification { get => _hideDisconnectedPowerLinesNotification; set => Set(ref _hideDisconnectedPowerLinesNotification, value, nameof(HideDisconnectedPowerLinesNotification)); }

        #endregion
    }
}