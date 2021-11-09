﻿using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.HideItBobby.Features;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.HideItBobby.Scripts;
using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Translation;
using com.github.TheCSUser.HideItBobby.UserInterface;
using com.github.TheCSUser.Shared.UserInterface;
using com.github.TheCSUser.Shared.UserInterface.Localization;
using System;
using System.IO;
using System.Linq;

namespace com.github.TheCSUser.HideItBobby
{
    using static ModProperties;
    using static Palette;
    using static Phrase;
    using static Styles;

    public sealed partial class Mod
    {
        protected override void BuildSettingsUI(BuilderSelection builders)
        {
            var builder = builders.LocalizedBuilder;

            try
            {
                var naturalDisastersDLCEnabledCheck = Context.Resolve<NaturalDisastersDLCEnabledCheck>();
                var snowFallDLCEnabledCheck = Context.Resolve<SnowFallDLCEnabledCheck>();
                var bobModDisabledCheck = Context.Resolve<BOBModDisabledCheck>();
                var terraformNetworkSubscribedCheck = Context.Resolve<TerraformNetworkSubscribedCheck>();

                #region Dev tools
#if DEV
                var devTools = builder.AddGroup(DevToolsHeader, textScale: 2, textColor: HoneyYellow).Builder;

                devTools.AddSpace(3);
                devTools.AddLabel(DevToolsDescriptionLine1);
                devTools.AddLabel(DevToolsDescriptionLine2, textColor: RedRYB);
                devTools.AddSpace(3);

                devTools.AddButton(new LocaleText(DevToolsEnable, ShortName), button => OnEnabled());
                devTools.AddButton(new LocaleText(DevToolsDisable, ShortName), button => OnDisabled());
                devTools.AddSpace(6);
                devTools.AddButton(new LocaleText(DevToolsInitialize, nameof(MainMenuFeatures)), button => MainMenuFeatures.GetLifecycleManager().Initialize());
                devTools.AddButton(new LocaleText(DevToolsEnable, nameof(MainMenuFeatures)), button => MainMenuFeatures.Enable());
                devTools.AddButton(new LocaleText(DevToolsTerminate, nameof(MainMenuFeatures)), button =>
                {
                    MainMenuFeatures.Disable();
                    MainMenuFeatures.GetLifecycleManager().Terminate();
                });
                devTools.AddSpace(6);
                devTools.AddButton(new LocaleText(DevToolsInitialize, nameof(InGameFeatures)), button => InGameFeatures.GetLifecycleManager().Initialize());
                devTools.AddButton(new LocaleText(DevToolsEnable, nameof(InGameFeatures)), button => InGameFeatures.Enable());
                devTools.AddButton(new LocaleText(DevToolsTerminate, nameof(InGameFeatures)), button =>
                {
                    InGameFeatures.Disable();
                    InGameFeatures.GetLifecycleManager().Terminate();
                });
                devTools.AddSpace(6);
                devTools.AddButton(DevToolsReloadSettings, button => LoadSettings());
                devTools.AddButton(DevToolsApplySettings, button => Settings.VersionCounter.Update());
                devTools.AddSpace(6);
                devTools.AddButton(DevToolsOverwriteLanguageFiles, button =>
                {
                    try
                    {
                        if (File.Exists(Paths.Translations.DE)) File.Delete(Paths.Translations.DE);
                        if (File.Exists(Paths.Translations.EN)) File.Delete(Paths.Translations.EN);
                        if (File.Exists(Paths.Translations.ES)) File.Delete(Paths.Translations.ES);
                        if (File.Exists(Paths.Translations.JA)) File.Delete(Paths.Translations.JA);
                        if (File.Exists(Paths.Translations.PL)) File.Delete(Paths.Translations.PL);
                        if (File.Exists(Paths.Translations.ZH)) File.Delete(Paths.Translations.ZH);
                        UnpackLocaleFiles();
                    }
                    catch (Exception e)
                    {
                        Log.Error($"{nameof(Mod)}.{nameof(BuildSettingsUI)}.Button eventCallback failed", e);
                    }
                });
#endif
                #endregion

                #region Language
                if (LocaleLibrary.AvailableLanguages.Count > 1)
                {
                    var langList = LocaleLibrary.AvailableLanguages.Values
                        .Select(x => x.TryGetValue(LanguageName, out var name) ? name : null)
                        .Where(x => !(x is null))
                        .ToList();
                    if (!langList.Contains(LocaleConstants.DEFAULT_LANGUAGE_NAME)) langList.Add(LocaleConstants.DEFAULT_LANGUAGE_NAME);
                    langList.Sort();

                    var selectedLang = LocaleLibrary.KeyToName(Settings.UseGameLanguage ? LocaleManager.GameLanguage : Settings.SelectedLanguage) ?? LocaleConstants.DEFAULT_LANGUAGE_NAME;
                    var selectedLangIx = langList.IndexOf(selectedLang);

                    var language = builder.AddGroup(LanguageHeader, textScale: 2, textColor: White).Builder;

                    var langDropdown = language.AddDropdown(
                        SelectLanguage,
                        langList.ToArray(),
                        selectedLangIx,
                        (component, selection) =>
                        {
                            try
                            {
                                if (Settings.UseGameLanguage) return;
                                var langKey = LocaleLibrary.NameToKey(langList[selection]);
                                Settings.SelectedLanguage = langKey;
                                LocaleManager.ChangeTo(langKey);
                            }
                            catch (Exception e)
                            {
                                Log.Error($"{nameof(Mod)}.{nameof(BuildSettingsUI)}.DropDown eventCallback failed", e);
                            }
                        });
                    langDropdown.ApplyStyle(DisableWhenUsingGameLanguage);
                    language.AddFeatureCheckbox(UseGameLanguage, Settings.UseGameLanguage, value =>
                    {
                        try
                        {
                            Settings.UseGameLanguage = value;
                            if (value)
                            {
                                LocaleManager.ChangeToGameLanguage();
                            }
                            else
                            {
                                LocaleManager.ChangeTo(Settings.SelectedLanguage);
                            }
                        }
                        catch (Exception e)
                        {
                            Log.Error($"{nameof(Mod)}.{nameof(BuildSettingsUI)}.CheckBox eventCallback failed", e);
                        }
                    });
                }
                #endregion

                var availableFeatures = builder.AddGroup(AvailableFeaturesHeader, textScale: 2, textColor: White).Builder;
                var unAvailableFeatures = builder.AddGroup(UnavailableFeaturesHeader, textScale: 2, textColor: White).Builder;
                unAvailableFeatures.AddLabel(UnavailableFeaturesDescription, textColor: HoneyYellow)
                    .ApplyStyle(HideEmptyLabel);
                unAvailableFeatures.AddLabel(UnavailableFeaturesDescriptionLine2, textColor: HoneyYellow)
                    .ApplyStyle(HideEmptyLabel);

                #region MainMenu
                availableFeatures.AddGroupHeader(MainMenuGroup);
                availableFeatures.AddFeatureCheckbox(MainMenuChirper, Settings.HideMainMenuChirper, value => Settings.HideMainMenuChirper = value);
                availableFeatures.AddFeatureCheckbox(MainMenuDLCPanel, Settings.HideMainMenuDLCPanel, value => Settings.HideMainMenuDLCPanel = value);
                availableFeatures.AddFeatureCheckbox(MainMenuLogoImage, Settings.HideMainMenuLogo, value => Settings.HideMainMenuLogo = value);
                availableFeatures.AddFeatureCheckbox(MainMenuNewsPanel, Settings.HideMainMenuNewsPanel, value => Settings.HideMainMenuNewsPanel = value);
                availableFeatures.AddFeatureCheckbox(MainMenuParadoxAccountPanel, Settings.HideMainMenuParadoxAccountPanel, value => Settings.HideMainMenuParadoxAccountPanel = value);
                availableFeatures.AddFeatureCheckbox(MainMenuVersionNumber, Settings.HideMainMenuVersionNumber, value => Settings.HideMainMenuVersionNumber = value);
                availableFeatures.AddFeatureCheckbox(MainMenuWorkshopPanel, Settings.HideMainMenuWorkshopPanel, value => Settings.HideMainMenuWorkshopPanel = value);
                #endregion

                #region UIElements
                availableFeatures.AddGroupHeader(InGameUIGroup);
                availableFeatures.AddFeatureCheckbox(InfoViewsButton, Settings.HideInfoViewsButton, value => Settings.HideInfoViewsButton = value);
                if (naturalDisastersDLCEnabledCheck.Result)
                {
                    availableFeatures.AddFeatureCheckbox(DisastersButton, Settings.HideDisastersButton, value => Settings.HideDisastersButton = value);
                }
                availableFeatures.AddFeatureCheckbox(ChirperButton, Settings.HideChirperButton, value => Settings.HideChirperButton = value);
                availableFeatures.AddFeatureCheckbox(RadioButton, Settings.HideRadioButton, value => Settings.HideRadioButton = value);
                availableFeatures.AddFeatureCheckbox(GearButton, Settings.HideGearButton, value => Settings.HideGearButton = value);
                availableFeatures.AddFeatureCheckbox(ZoomButton, Settings.HideZoomButton, value => Settings.HideZoomButton = value);
                availableFeatures.AddFeatureCheckbox(UnlockButton, Settings.HideUnlockButton, value => Settings.HideUnlockButton = value);
                availableFeatures.AddFeatureCheckbox(AdvisorPanel, Settings.HideAdvisorPanel, value => Settings.HideAdvisorPanel = value);
                availableFeatures.AddFeatureCheckbox(AdvisorButton, Settings.HideAdvisorButton, value => Settings.HideAdvisorButton = value);
                availableFeatures.AddFeatureCheckbox(BulldozerBar, Settings.HideBulldozerBar, value => Settings.HideBulldozerBar = value);
                availableFeatures.AddFeatureCheckbox(BulldozerButton, Settings.HideBulldozerButton, value => Settings.HideBulldozerButton = value);
                availableFeatures.AddFeatureCheckbox(CinematicCameraButton, Settings.HideCinematicCameraButton, value => Settings.HideCinematicCameraButton = value);
                availableFeatures.AddFeatureCheckbox(FreeCameraButton, Settings.HideFreeCameraButton, value => Settings.HideFreeCameraButton = value);
                availableFeatures.AddFeatureCheckbox(CongratulationPanel, Settings.HideCongratulationPanel, value => Settings.HideCongratulationPanel = value);
                availableFeatures.AddFeatureCheckbox(TimePanel, Settings.HideTimePanel, value => Settings.HideTimePanel = value);
                availableFeatures.AddFeatureCheckbox(ZoomAndUnlockBackground, Settings.HideZoomAndUnlockBackground, value => Settings.HideZoomAndUnlockBackground = value);
                availableFeatures.AddFeatureCheckbox(Separators, Settings.HideSeparators, value => Settings.HideSeparators = value);
                availableFeatures.AddFeatureCheckbox(CityName, Settings.HideCityName, value => Settings.HideCityName = value);
                availableFeatures.AddFeatureCheckbox(PauseOutlineEffect, Settings.HidePauseOutline, value => Settings.HidePauseOutline = value);
                if (snowFallDLCEnabledCheck.Result)
                {
                    availableFeatures.AddFeatureCheckbox(Thermometer, Settings.HideThermometer, value => Settings.HideThermometer = value);
                }
                availableFeatures.AddFeatureCheckbox(ModifyToolbarPosition, Settings.ModifyToolbarPosition, value => Settings.ModifyToolbarPosition = value);
                availableFeatures
                    .AddSlider(null, 0.0f, 1.0f, 0.01f, Settings.ToolbarPosition, (_, newValue) => Settings.ToolbarPosition = newValue, width: 700f)
                    .ApplyStyle(HideEmptyLabel)
                    .ApplyStyle(DisableWhenNotModifyingPosition);
                #endregion

                #region Objects
                availableFeatures.AddGroupHeader(ObjectsAndPropsGroup);
                availableFeatures.AddFeatureCheckbox(Seagulls, Settings.HideSeagulls, value => Settings.HideSeagulls = value);
                availableFeatures.AddFeatureCheckbox(Wildlife, Settings.HideWildlife, value => Settings.HideWildlife = value);
                #endregion

                #region Decorations
                availableFeatures.AddGroupHeader(DecorationsGroup);
                availableFeatures.AddFeatureCheckbox(CliffDecorations, Settings.HideCliffDecorations, value => Settings.HideCliffDecorations = value);
                availableFeatures.AddFeatureCheckbox(GrassDecorations, Settings.HideGrassDecorations, value => Settings.HideGrassDecorations = value);
                availableFeatures.AddFeatureCheckbox(FertileDecorations, Settings.HideFertileDecorations, value => Settings.HideFertileDecorations = value);
                #endregion

                #region Ruining
                var ruiningIsCompatible = bobModDisabledCheck.Result;
                if (ruiningIsCompatible)
                {
                    availableFeatures.AddGroupHeader(RuiningGroup);
                    availableFeatures.AddFeatureCheckbox(TreeRuining, Settings.HideTreeRuining, value => Settings.HideTreeRuining = value);
                    availableFeatures.AddFeatureCheckbox(PropRuining, Settings.HidePropRuining, value => Settings.HidePropRuining = value);
                    availableFeatures.AddSpace(3);
                    availableFeatures.AddButton(UpdateRuiningButton, button =>
                    {
                        try
                        {
#if DEV
                            Log.Info($"updating ruining under trees");
#endif
                            FeatureFlags flags;
                            flags = InGameFeatures.Features.Resolve(FeatureKey.HideTreeRuining).Run();
#if DEV
                            Log.Info($"flags: {flags}");
                            Log.Info($"updating ruining under props");
#endif
                            flags = InGameFeatures.Features.Resolve(FeatureKey.HidePropRuining).Run();
#if DEV
                            Log.Info($"flags: {flags}");
#endif
                        }
                        catch (Exception e)
                        {
                            Log.Error($"{nameof(Mod)}.{nameof(BuildSettingsUI)}.Button eventCallback failed", e);
                        }
                    });
                }
                else
                {
                    unAvailableFeatures.AddGroupHeader(RuiningGroup);
                    unAvailableFeatures.AddLabel(RuiningUnavailableDescriptionLine1, textColor: White)
                        .ApplyStyle(HideEmptyLabel);
                    unAvailableFeatures.AddLabel(RuiningUnavailableDescriptionLine2, textColor: White)
                        .ApplyStyle(HideEmptyLabel);
                    unAvailableFeatures.AddLabel(RuiningUnavailableDescriptionLine3, textColor: White)
                        .ApplyStyle(HideEmptyLabel);
                    unAvailableFeatures.AddSpace(3);
                    unAvailableFeatures.AddUnavailableFeatureCheckbox(TreeRuining, Settings.HideTreeRuining, value => Settings.HideTreeRuining = value);
                    unAvailableFeatures.AddUnavailableFeatureCheckbox(PropRuining, Settings.HidePropRuining, value => Settings.HidePropRuining = value);
                }
                #endregion

                #region GroundAndWaterColor
                availableFeatures.AddGroupHeader(GroundAndWaterColorGroup);
                availableFeatures.AddFeatureCheckbox(GrassFertilityGroundColor, Settings.DisableGrassFertilityGroundColor, value => Settings.DisableGrassFertilityGroundColor = value);
                availableFeatures.AddFeatureCheckbox(GrassFieldGroundColor, Settings.DisableGrassFieldGroundColor, value => Settings.DisableGrassFieldGroundColor = value);
                availableFeatures.AddFeatureCheckbox(GrassForestGroundColor, Settings.DisableGrassForestGroundColor, value => Settings.DisableGrassForestGroundColor = value);
                availableFeatures.AddFeatureCheckbox(GrassPollutionGroundColor, Settings.DisableGrassPollutionGroundColor, value => Settings.DisableGrassPollutionGroundColor = value);
                availableFeatures.AddFeatureCheckbox(DirtyWaterColor, Settings.DisableDirtyWaterColor, value => Settings.DisableDirtyWaterColor = value);
                #endregion

                #region Effects
                availableFeatures.AddGroupHeader(EffectsGroup);
                availableFeatures.AddFeatureCheckbox(OreAreaEffect, Settings.HideOreArea, value => Settings.HideOreArea = value);
                availableFeatures.AddFeatureCheckbox(OilAreaEffect, Settings.HideOilArea, value => Settings.HideOilArea = value);
                availableFeatures.AddFeatureCheckbox(SandAreaEffect, Settings.HideSandArea, value => Settings.HideSandArea = value);
                availableFeatures.AddFeatureCheckbox(FertilityAreaEffect, Settings.HideFertilityArea, value => Settings.HideFertilityArea = value);
                availableFeatures.AddFeatureCheckbox(ForestAreaEffect, Settings.HideForestArea, value => Settings.HideForestArea = value);
                availableFeatures.AddFeatureCheckbox(ShoreAreaEffect, Settings.HideShoreArea, value => Settings.HideShoreArea = value);
                availableFeatures.AddFeatureCheckbox(PollutedAreaEffect, Settings.HidePollutedArea, value => Settings.HidePollutedArea = value);
                availableFeatures.AddFeatureCheckbox(BurnedAreaEffect, Settings.HideBurnedArea, value => Settings.HideBurnedArea = value);
                availableFeatures.AddFeatureCheckbox(DestroyedAreaEffect, Settings.HideDestroyedArea, value => Settings.HideDestroyedArea = value);
                availableFeatures.AddFeatureCheckbox(PollutionFog, Settings.HidePollutionFog, value => Settings.HidePollutionFog = value);
                availableFeatures.AddFeatureCheckbox(VolumeFog, Settings.HideVolumeFog, value => Settings.HideVolumeFog = value);
                availableFeatures.AddFeatureCheckbox(DistanceFog, Settings.HideDistanceFog, value => Settings.HideDistanceFog = value);
                availableFeatures.AddFeatureCheckbox(EdgeFog, Settings.HideEdgeFog, value => Settings.HideEdgeFog = value);
                #endregion

                #region Problems
#if DEV
                availableFeatures.AddGroupHeader(ProblemsGroup);
                if (terraformNetworkSubscribedCheck.Result) availableFeatures.AddFeatureCheckbox(TerraformNetworkFloodNotification, Settings.HideTerraformNetworkFloodNotification, value => Settings.HideTerraformNetworkFloodNotification = value);
                availableFeatures.AddFeatureCheckbox(HideDisconnectedPowerLinesNotification, Settings.HideDisconnectedPowerLinesNotification, value => Settings.HideDisconnectedPowerLinesNotification = value);
#endif
                #endregion
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(Mod)}.{nameof(BuildSettingsUI)} failed", e);
            }
        }
    }
}