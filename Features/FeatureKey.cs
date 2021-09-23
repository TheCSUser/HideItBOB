using com.github.TheCSUser.Shared.Imports;

namespace com.github.TheCSUser.HideItBobby.Features
{
    ///<completionlist cref="FeatureKey"/>
    internal sealed class FeatureKey : StringEnum<FeatureKey>
    {
        //Decorations
        public static readonly FeatureKey HideCliffDecorations = Create(nameof(HideCliffDecorations));
        public static readonly FeatureKey HideFertileDecorations = Create(nameof(HideFertileDecorations));
        public static readonly FeatureKey HideGrassDecorations = Create(nameof(HideGrassDecorations));

        //Effects
        public static readonly FeatureKey HideOreAreaEffect = Create(nameof(HideOreAreaEffect));
        public static readonly FeatureKey HideOilAreaEffect = Create(nameof(HideOilAreaEffect));
        public static readonly FeatureKey HideSandAreaEffect = Create(nameof(HideSandAreaEffect));
        public static readonly FeatureKey HideFertilityAreaEffect = Create(nameof(HideFertilityAreaEffect));
        public static readonly FeatureKey HideForestAreaEffect = Create(nameof(HideForestAreaEffect));
        public static readonly FeatureKey HideShoreAreaEffect = Create(nameof(HideShoreAreaEffect));
        public static readonly FeatureKey HidePollutedAreaEffect = Create(nameof(HidePollutedAreaEffect));
        public static readonly FeatureKey HideBurnedAreaEffect = Create(nameof(HideBurnedAreaEffect));
        public static readonly FeatureKey HideDestroyedAreaEffect = Create(nameof(HideDestroyedAreaEffect));
        public static readonly FeatureKey HidePollutionFog = Create(nameof(HidePollutionFog));
        public static readonly FeatureKey HideVolumeFog = Create(nameof(HideVolumeFog));
        public static readonly FeatureKey HideDistanceFog = Create(nameof(HideDistanceFog));
        public static readonly FeatureKey HideEdgeFog = Create(nameof(HideEdgeFog));

        //GroundAndWaterColor
        public static readonly FeatureKey DisableGrassFertilityGroundColor = Create(nameof(DisableGrassFertilityGroundColor));
        public static readonly FeatureKey DisableGrassFieldGroundColor = Create(nameof(DisableGrassFieldGroundColor));
        public static readonly FeatureKey DisableGrassForestGroundColor = Create(nameof(DisableGrassForestGroundColor));
        public static readonly FeatureKey DisableGrassPollutionGroundColor = Create(nameof(DisableGrassPollutionGroundColor));
        public static readonly FeatureKey DisableDirtyWaterColor = Create(nameof(DisableDirtyWaterColor));

        //MainManu
        public static readonly FeatureKey HideMainMenuChirper = Create(nameof(HideMainMenuChirper));
        public static readonly FeatureKey HideMainMenuDLCPanel = Create(nameof(HideMainMenuDLCPanel));
        public static readonly FeatureKey HideMainMenuLogo = Create(nameof(HideMainMenuLogo));
        public static readonly FeatureKey HideMainMenuNewsPanel = Create(nameof(HideMainMenuNewsPanel));
        public static readonly FeatureKey HideMainMenuParadoxAccountPanel = Create(nameof(HideMainMenuParadoxAccountPanel));
        public static readonly FeatureKey HideMainMenuVersionNumber = Create(nameof(HideMainMenuVersionNumber));
        public static readonly FeatureKey HideMainMenuWorkshopPanel = Create(nameof(HideMainMenuWorkshopPanel));

        //Objects
        public static readonly FeatureKey HideSeagulls = Create(nameof(HideSeagulls));
        public static readonly FeatureKey HideWildlife = Create(nameof(HideWildlife));

        //UIElements
        public static readonly FeatureKey HideAdvisorButton = Create(nameof(HideAdvisorButton));
        public static readonly FeatureKey HideBulldozerButton = Create(nameof(HideBulldozerButton));
        public static readonly FeatureKey HideChirperButton = Create(nameof(HideChirperButton));
        public static readonly FeatureKey HideCinematicCameraButton = Create(nameof(HideCinematicCameraButton));
        public static readonly FeatureKey HideCityName = Create(nameof(HideCityName));
        public static readonly FeatureKey HideDisastersButton = Create(nameof(HideDisastersButton));
        public static readonly FeatureKey HideFreeCameraButton = Create(nameof(HideFreeCameraButton));
        public static readonly FeatureKey HideGearButton = Create(nameof(HideGearButton));
        public static readonly FeatureKey HideInfoViewsButton = Create(nameof(HideInfoViewsButton));
        public static readonly FeatureKey HideRadioButton = Create(nameof(HideRadioButton));
        public static readonly FeatureKey HideSeparators = Create(nameof(HideSeparators));
        public static readonly FeatureKey HideTimePanel = Create(nameof(HideTimePanel));
        public static readonly FeatureKey HideUnlockButton = Create(nameof(HideUnlockButton));
        public static readonly FeatureKey HideZoomAndUnlockBackground = Create(nameof(HideZoomAndUnlockBackground));
        public static readonly FeatureKey HideZoomButton = Create(nameof(HideZoomButton));
        public static readonly FeatureKey HideCongratulationPanel = Create(nameof(HideCongratulationPanel));
        public static readonly FeatureKey HideAdvisorPanel = Create(nameof(HideAdvisorPanel));
        public static readonly FeatureKey HidePauseOutline = Create(nameof(HidePauseOutline));
        public static readonly FeatureKey HideBulldozerBar = Create(nameof(HideBulldozerBar));
        public static readonly FeatureKey HideThermometer = Create(nameof(HideThermometer));
        public static readonly FeatureKey ToolbarPosition = Create(nameof(ToolbarPosition));

        //Ruining
        public static readonly FeatureKey HideTreeRuining = Create(nameof(HideTreeRuining));
        public static readonly FeatureKey HidePropRuining = Create(nameof(HidePropRuining));

        //Problems
        public static readonly FeatureKey HideTerraformNetworkFloodNotification = Create(nameof(HideTerraformNetworkFloodNotification));
        public static readonly FeatureKey HideDisconnectedPowerLinesNotification = Create(nameof(HideDisconnectedPowerLinesNotification));

        //Fixes
        public static readonly FeatureKey LowerInfoPanelZOrder = Create(nameof(LowerInfoPanelZOrder));
    }
}