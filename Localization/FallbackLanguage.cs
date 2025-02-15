﻿using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.UserInterface.Localization;
using System.Collections.Generic;
using static com.github.TheCSUser.HideItBobby.Localization.Phrase;

namespace com.github.TheCSUser.HideItBobby.Localization
{
    internal static class FallbackLanguage
    {
        public static ILanguageDictionary Build(IModContext context) => new LanguageDictionary(context, new Dictionary<string, string>()
        {
#if DEV
            //dev tools
            { DevToolsHeader, "Dev Tools" },
            { DevToolsDescriptionLine1, "You are seeing this section because you are using the development version of this mod." },
            { DevToolsDescriptionLine2, "Please make sure that you know what you are doing." },
            { DevToolsEnable, "Enable %1" },
            { DevToolsDisable, "Disable %1" },
            { DevToolsInitialize, "Initialize %1" },
            { DevToolsTerminate, "Terminate %1" },
            { DevToolsReloadSettings, "Reload settings" },
            { DevToolsApplySettings, "Force apply settings" },
            { DevToolsOverwriteLanguageFiles, "Overwrite language files with default versions" },
            { DevToolsReloadLanguageFiles, "Reload language files" },
#endif
            //language
            { LanguageName, "English" },
            { LanguageHeader, "Language" },
            { UseGameLanguage, "Use game language"},
            { SelectLanguage, "Select language" },
            //features
            { AvailableFeaturesHeader,"Available features" },
            { UnavailableFeaturesHeader,"Unavailable features" },
            { UnavailableFeaturesDescription,"Features visible in this section are disabled due to a conflict with another mod." },
            { UnavailableFeaturesDescriptionLine2, "" },
            //main menu
            { MainMenuGroup,"Main menu UI" },
            { MainMenuChirper,"Hide chirper" },
            { MainMenuDLCPanel,"Hide DLC panel" },
            { MainMenuLogoImage,"Hide logo" },
            { MainMenuNewsPanel,"Hide news panel" },
            { MainMenuParadoxAccountPanel,"Hide Paradox account panel" },
            { MainMenuVersionNumber,"Hide version" },
            { MainMenuWorkshopPanel,"Hide workshop panel" },
            //ui elements
            { InGameUIGroup,"In-game UI" },
            { AdvisorButton,"Hide advisor button" },
            { BulldozerButton,"Hide bulldozer button" },
            { ChirperButton,"Hide chirper button" },
            { CinematicCameraButton,"Hide cinematic camera button" },
            { CityName,"Hide city name" },
            { ModifyCityNamePosition,"Modify city name position" },
            { DisastersButton,"Hide disasters button" },
            { FreeCameraButton,"Hide free camera button" },
            { GearButton,"Hide gear button" },
            { InfoViewsButton,"Hide info views button" },
            { RadioButton,"Hide radio button" },
            { Separators,"Hide separators in toolbar" },
            { TimePanel,"Hide time panel" },
            { UnlockButton,"Hide unlock button" },
            { ZoomAndUnlockBackground,"Hide zoom and unlock background" },
            { ZoomButton,"Hide zoom button" },
            { CongratulationPanel,"Hide congratulation panel" },
            { AdvisorPanel,"Hide advisor panel" },
            { PauseOutlineEffect,"Hide pause outline" },
            { BulldozerBar,"Hide bulldozer bar" },
            { Thermometer,"Hide thermometer" },
            { ModifyToolbarPosition,"Modify toolbar position" },
            { CursorInfoHeader,"Hide cursor info popup when placing or destroying:" },
            { NetworksCursorInfo,"roads and other networks" },
            { BuildingsCursorInfo,"buildings" },
            { TreesCursorInfo,"trees" },
            { PropsCursorInfo,"props" },
            //objects and props
            { ObjectsAndPropsGroup,"Objects and props" },
            { Seagulls,"Remove seagulls" },
            { Wildlife,"Remove wildlife" },
            //decorations
            { DecorationsGroup,"Sprites" },
            { OverrideThemeMixer2,"Override Theme Mixer 2 settings" },
            { CliffDecorations,"Hide cliff decorations" },
            { FertileDecorations,"Hide fertile decorations" },
            { GrassDecorations,"Hide grass decorations" },
            //ruining
            { RuiningGroup,"Ruining" },
            { TreeRuining,"Hide trees ruining" },
            { PropRuining,"Hide props ruining" },
            { UpdateRuiningButton,"Update ruining on existing trees and props now!" },
            { RuiningUnavailableDescriptionLine1,"You are using BOB with hiding of ruining feature." },
            { RuiningUnavailableDescriptionLine2,"Please use BOB instead of this mod to hide tree and prop ruining." },
            { RuiningUnavailableDescriptionLine3,"" },
            //ground and water colors
            { GroundAndWaterColorGroup,"Ground and water colors" },
            { GrassFertilityGroundColor,"Remove grass fertility ground color" },
            { GrassFieldGroundColor,"Remove grass field ground color" },
            { GrassForestGroundColor,"Remove grass forest ground color" },
            { GrassPollutionGroundColor,"Remove grass pollution ground color" },
            { DirtyWaterColor,"Remove dirty water color" },
            //effects
            { EffectsGroup,"Effects" },
            { OreAreaEffect,"Hide ore area" },
            { OilAreaEffect,"Hide oil area" },
            { SandAreaEffect,"Hide sand area" },
            { FertilityAreaEffect,"Hide fertility area" },
            { ForestAreaEffect,"Hide forest area" },
            { ShoreAreaEffect,"Hide shore area" },
            { PollutedAreaEffect,"Hide polluted area" },
            { BurnedAreaEffect,"Hide burned area" },
            { DestroyedAreaEffect,"Hide destroyed area" },
            { PollutionFog,"Hide pollution fog" },
            { VolumeFog,"Hide volume fog" },
            { DistanceFog,"Hide distance fog" },
            { EdgeFog,"Hide edge fog" },
            { PlacementEffect, "Disable placement effect"},
            { BulldozingEffect, "Disable bulldozing effect"},
            { DisablePlacementBulldozingEffectUnavailableDescriptionLine1, "Disabling placement and bulldozing effect is unavailable"},
            { DisablePlacementBulldozingEffectUnavailableDescriptionLine2, "because you have Subtle Bulldozing, Dragging and More! mod enabled."},
            { DisablePlacementBulldozingEffectUnavailableDescriptionLine3, ""},
            //problems
            { ProblemsGroup, "Problems" },
            { TerraformNetworkFloodNotification, "Hide flood notification for Terraform Network" },
            { HideDisconnectedPowerLinesNotification, "Hide notification for disconnected power lines" },
        });
    }
}
