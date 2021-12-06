using com.github.TheCSUser.Shared.Imports;

namespace com.github.TheCSUser.HideItBobby.Localization
{
    ///<completionlist cref="Phrase"/>
    internal sealed class Phrase : StringEnum<Phrase>
    {
        //dev tools
        public static readonly Phrase DevToolsHeader = Create(nameof(DevToolsHeader));
        public static readonly Phrase DevToolsDescriptionLine1 = Create(nameof(DevToolsDescriptionLine1));
        public static readonly Phrase DevToolsDescriptionLine2 = Create(nameof(DevToolsDescriptionLine2));
        public static readonly Phrase DevToolsEnable = Create(nameof(DevToolsEnable));
        public static readonly Phrase DevToolsDisable = Create(nameof(DevToolsDisable));
        public static readonly Phrase DevToolsInitialize = Create(nameof(DevToolsInitialize));
        public static readonly Phrase DevToolsTerminate = Create(nameof(DevToolsTerminate));
        public static readonly Phrase DevToolsReloadSettings = Create(nameof(DevToolsReloadSettings));
        public static readonly Phrase DevToolsApplySettings = Create(nameof(DevToolsApplySettings));
        public static readonly Phrase DevToolsOverwriteLanguageFiles = Create(nameof(DevToolsOverwriteLanguageFiles));
        public static readonly Phrase DevToolsReloadLanguageFiles = Create(nameof(DevToolsReloadLanguageFiles));
        //language
        public static readonly Phrase LanguageName = Create(nameof(LanguageName));
        public static readonly Phrase LanguageHeader = Create(nameof(LanguageHeader));
        public static readonly Phrase UseGameLanguage = Create(nameof(UseGameLanguage));
        public static readonly Phrase SelectLanguage = Create(nameof(SelectLanguage));
        //features
        public static readonly Phrase AvailableFeaturesHeader = Create(nameof(AvailableFeaturesHeader));
        public static readonly Phrase UnavailableFeaturesHeader = Create(nameof(UnavailableFeaturesHeader));
        public static readonly Phrase UnavailableFeaturesDescription = Create(nameof(UnavailableFeaturesDescription));
        public static readonly Phrase UnavailableFeaturesDescriptionLine2 = Create(nameof(UnavailableFeaturesDescriptionLine2));
        //MainManu
        public static readonly Phrase MainMenuGroup = Create(nameof(MainMenuGroup));
        public static readonly Phrase MainMenuChirper = Create(nameof(MainMenuChirper));
        public static readonly Phrase MainMenuDLCPanel = Create(nameof(MainMenuDLCPanel));
        public static readonly Phrase MainMenuLogoImage = Create(nameof(MainMenuLogoImage));
        public static readonly Phrase MainMenuNewsPanel = Create(nameof(MainMenuNewsPanel));
        public static readonly Phrase MainMenuParadoxAccountPanel = Create(nameof(MainMenuParadoxAccountPanel));
        public static readonly Phrase MainMenuVersionNumber = Create(nameof(MainMenuVersionNumber));
        public static readonly Phrase MainMenuWorkshopPanel = Create(nameof(MainMenuWorkshopPanel));
        //UIElements
        public static readonly Phrase InGameUIGroup = Create(nameof(InGameUIGroup));
        public static readonly Phrase AdvisorButton = Create(nameof(AdvisorButton));
        public static readonly Phrase BulldozerButton = Create(nameof(BulldozerButton));
        public static readonly Phrase ChirperButton = Create(nameof(ChirperButton));
        public static readonly Phrase CinematicCameraButton = Create(nameof(CinematicCameraButton));
        public static readonly Phrase CityName = Create(nameof(CityName));
        public static readonly Phrase DisastersButton = Create(nameof(DisastersButton));
        public static readonly Phrase FreeCameraButton = Create(nameof(FreeCameraButton));
        public static readonly Phrase GearButton = Create(nameof(GearButton));
        public static readonly Phrase InfoViewsButton = Create(nameof(InfoViewsButton));
        public static readonly Phrase RadioButton = Create(nameof(RadioButton));
        public static readonly Phrase Separators = Create(nameof(Separators));
        public static readonly Phrase TimePanel = Create(nameof(TimePanel));
        public static readonly Phrase UnlockButton = Create(nameof(UnlockButton));
        public static readonly Phrase ZoomAndUnlockBackground = Create(nameof(ZoomAndUnlockBackground));
        public static readonly Phrase ZoomButton = Create(nameof(ZoomButton));
        public static readonly Phrase CongratulationPanel = Create(nameof(CongratulationPanel));
        public static readonly Phrase AdvisorPanel = Create(nameof(AdvisorPanel));
        public static readonly Phrase PauseOutlineEffect = Create(nameof(PauseOutlineEffect));
        public static readonly Phrase BulldozerBar = Create(nameof(BulldozerBar));
        public static readonly Phrase Thermometer = Create(nameof(Thermometer));
        public static readonly Phrase ModifyToolbarPosition = Create(nameof(ModifyToolbarPosition));
        public static readonly Phrase CursorInfoHeader = Create(nameof(CursorInfoHeader));
        public static readonly Phrase NetworksCursorInfo = Create(nameof(NetworksCursorInfo));
        public static readonly Phrase BuildingsCursorInfo = Create(nameof(BuildingsCursorInfo));
        public static readonly Phrase TreesCursorInfo = Create(nameof(TreesCursorInfo));
        public static readonly Phrase PropsCursorInfo = Create(nameof(PropsCursorInfo));
        //Objects & props
        public static readonly Phrase ObjectsAndPropsGroup = Create(nameof(ObjectsAndPropsGroup));
        public static readonly Phrase Seagulls = Create(nameof(Seagulls));
        public static readonly Phrase Wildlife = Create(nameof(Wildlife));
        //Decorations
        public static readonly Phrase DecorationsGroup = Create(nameof(DecorationsGroup));
        public static readonly Phrase CliffDecorations = Create(nameof(CliffDecorations));
        public static readonly Phrase FertileDecorations = Create(nameof(FertileDecorations));
        public static readonly Phrase GrassDecorations = Create(nameof(GrassDecorations));
        //Ruining
        public static readonly Phrase RuiningGroup = Create(nameof(RuiningGroup));
        public static readonly Phrase TreeRuining = Create(nameof(TreeRuining));
        public static readonly Phrase PropRuining = Create(nameof(PropRuining));
        public static readonly Phrase UpdateRuiningButton = Create(nameof(UpdateRuiningButton));
        public static readonly Phrase RuiningUnavailableDescriptionLine1 = Create(nameof(RuiningUnavailableDescriptionLine1));
        public static readonly Phrase RuiningUnavailableDescriptionLine2 = Create(nameof(RuiningUnavailableDescriptionLine2));
        public static readonly Phrase RuiningUnavailableDescriptionLine3 = Create(nameof(RuiningUnavailableDescriptionLine3));
        //GroundAndWaterColor
        public static readonly Phrase GroundAndWaterColorGroup = Create(nameof(GroundAndWaterColorGroup));
        public static readonly Phrase GrassFertilityGroundColor = Create(nameof(GrassFertilityGroundColor));
        public static readonly Phrase GrassFieldGroundColor = Create(nameof(GrassFieldGroundColor));
        public static readonly Phrase GrassForestGroundColor = Create(nameof(GrassForestGroundColor));
        public static readonly Phrase GrassPollutionGroundColor = Create(nameof(GrassPollutionGroundColor));
        public static readonly Phrase DirtyWaterColor = Create(nameof(DirtyWaterColor));
        //Effects
        public static readonly Phrase EffectsGroup = Create(nameof(EffectsGroup));
        public static readonly Phrase OreAreaEffect = Create(nameof(OreAreaEffect));
        public static readonly Phrase OilAreaEffect = Create(nameof(OilAreaEffect));
        public static readonly Phrase SandAreaEffect = Create(nameof(SandAreaEffect));
        public static readonly Phrase FertilityAreaEffect = Create(nameof(FertilityAreaEffect));
        public static readonly Phrase ForestAreaEffect = Create(nameof(ForestAreaEffect));
        public static readonly Phrase ShoreAreaEffect = Create(nameof(ShoreAreaEffect));
        public static readonly Phrase PollutedAreaEffect = Create(nameof(PollutedAreaEffect));
        public static readonly Phrase BurnedAreaEffect = Create(nameof(BurnedAreaEffect));
        public static readonly Phrase DestroyedAreaEffect = Create(nameof(DestroyedAreaEffect));
        public static readonly Phrase PollutionFog = Create(nameof(PollutionFog));
        public static readonly Phrase VolumeFog = Create(nameof(VolumeFog));
        public static readonly Phrase DistanceFog = Create(nameof(DistanceFog));
        public static readonly Phrase EdgeFog = Create(nameof(EdgeFog));
        public static readonly Phrase PlacementEffect = Create(nameof(PlacementEffect));
        public static readonly Phrase BulldozingEffect = Create(nameof(BulldozingEffect));
        public static readonly Phrase DisablePlacementBulldozingEffectUnavailableDescriptionLine1 = Create(nameof(DisablePlacementBulldozingEffectUnavailableDescriptionLine1));
        public static readonly Phrase DisablePlacementBulldozingEffectUnavailableDescriptionLine2 = Create(nameof(DisablePlacementBulldozingEffectUnavailableDescriptionLine2));
        public static readonly Phrase DisablePlacementBulldozingEffectUnavailableDescriptionLine3 = Create(nameof(DisablePlacementBulldozingEffectUnavailableDescriptionLine3));
        //Problems
        public static readonly Phrase ProblemsGroup = Create(nameof(ProblemsGroup));
        public static readonly Phrase TerraformNetworkFloodNotification = Create(nameof(TerraformNetworkFloodNotification));
        public static readonly Phrase HideDisconnectedPowerLinesNotification = Create(nameof(HideDisconnectedPowerLinesNotification));
    }
}