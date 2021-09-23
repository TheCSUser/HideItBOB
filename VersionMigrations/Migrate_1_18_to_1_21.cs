using com.github.TheCSUser.HideItBobby.Settings;
using com.github.TheCSUser.HideItBobby.Settings.Providers;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Imports;
using System.IO;

namespace com.github.TheCSUser.HideItBobby.VersionMigrations
{
    using static File;
    using static Paths.Config;

    internal class Migrate_1_18_to_1_21 : Migration
    {
        private readonly Provider_1_17 Provider_1_17;
        private readonly Provider_1_19 Provider_1_19;
        private readonly Provider_1_21 Provider_1_21;

        public Migrate_1_18_to_1_21(IModContext context) : base(context)
        {
            Provider_1_17 = new Provider_1_17(context);
            Provider_1_19 = new Provider_1_19(context);
            Provider_1_21 = new Provider_1_21(context);
        }

        public override void Migrate()
        {
            if (Exists(File_1_21)) return;

            var file_1_17 = Provider_1_17.Load();
            var file_1_19 = Provider_1_19.Load();

            if (file_1_17 is null && file_1_19 is null) return;

#if DEV
            Log.Info($"{nameof(SettingsProvider)}.{nameof(Migrate)} {nameof(file_1_17)} deserialized content");
            Log.Info(ObjectDumper.Dump(file_1_17));
            Log.Info($"{nameof(SettingsProvider)}.{nameof(Migrate)} {nameof(file_1_19)} deserialized content");
            Log.Info(ObjectDumper.Dump(file_1_19));
#endif

            var file_1_21 = new File_1_21
            {
                SelectedLanguage = "en",
                UseGameLanguage = true,

                #region Main menu features
                HideMainMenuChirper = false,
                HideMainMenuDLCPanel = false,
                HideMainMenuLogo = false,
                HideMainMenuNewsPanel = false,
                HideMainMenuParadoxAccountPanel = false,
                HideMainMenuVersionNumber = false,
                HideMainMenuWorkshopPanel = false,
                #endregion

                #region In game features
                //Decorations
                HideCliffDecorations = (file_1_19?.HideCliffDecorations) ?? (file_1_17?.HideCliffDecorations) ?? false,
                HideFertileDecorations = (file_1_19?.HideFertileDecorations) ?? (file_1_17?.HideFertileDecorations) ?? false,
                HideGrassDecorations = (file_1_19?.HideGrassDecorations) ?? (file_1_17?.HideGrassDecorations) ?? false,

                //Effects
                HideOreArea = (file_1_19?.HideOreArea) ?? (file_1_17?.HideOreArea) ?? false,
                HideOilArea = (file_1_19?.HideOilArea) ?? (file_1_17?.HideOilArea) ?? false,
                HideSandArea = (file_1_19?.HideSandArea) ?? (file_1_17?.HideSandArea) ?? false,
                HideFertilityArea = (file_1_19?.HideFertilityArea) ?? (file_1_17?.HideFertilityArea) ?? false,
                HideForestArea = (file_1_19?.HideForestArea) ?? (file_1_17?.HideForestArea) ?? false,
                HideShoreArea = (file_1_19?.HideShoreArea) ?? (file_1_17?.HideShoreArea) ?? false,
                HidePollutedArea = (file_1_19?.HidePollutedArea) ?? (file_1_17?.HidePollutedArea) ?? false,
                HideBurnedArea = (file_1_19?.HideBurnedArea) ?? (file_1_17?.HideBurnedArea) ?? false,
                HideDestroyedArea = (file_1_19?.HideDestroyedArea) ?? (file_1_17?.HideDestroyedArea) ?? false,
                HidePollutionFog = (file_1_19?.HidePollutionFog) ?? (file_1_17?.HidePollutionFog) ?? false,
                HideVolumeFog = (file_1_19?.HideVolumeFog) ?? (file_1_17?.HideVolumeFog) ?? false,
                HideDistanceFog = (file_1_19?.HideDistanceFog) ?? (file_1_17?.HideDistanceFog) ?? false,
                HideEdgeFog = (file_1_19?.HideEdgeFog) ?? (file_1_17?.HideEdgeFog) ?? false,

                //Ground and water color
                DisableGrassFertilityGroundColor = (file_1_19?.DisableGrassFertilityGroundColor) ?? (file_1_17?.DisableGrassFertilityGroundColor) ?? false,
                DisableGrassFieldGroundColor = (file_1_19?.DisableGrassFieldGroundColor) ?? (file_1_17?.DisableGrassFieldGroundColor) ?? false,
                DisableGrassForestGroundColor = (file_1_19?.DisableGrassForestGroundColor) ?? (file_1_17?.DisableGrassForestGroundColor) ?? false,
                DisableGrassPollutionGroundColor = (file_1_19?.DisableGrassPollutionGroundColor) ?? (file_1_17?.DisableGrassPollutionGroundColor) ?? false,
                DisableDirtyWaterColor = (file_1_19?.DisableDirtyWaterColor) ?? (file_1_17?.DisableDirtyWaterColor) ?? false,

                //Objects
                HideSeagulls = (file_1_19?.HideSeagulls) ?? (file_1_17?.HideSeagulls) ?? false,
                HideWildlife = (file_1_19?.HideWildlife) ?? (file_1_17?.HideWildlife) ?? false,

                //Ruining - Deprecated
                HideTreeRuining = (file_1_17?.HideTreeRuining) ?? false,
                HidePropRuining = (file_1_17?.HidePropRuining) ?? false,

                //In game ui elements
                HideInfoViewsButton = (file_1_19?.HideInfoViewsButton) ?? (file_1_17?.HideInfoViewsButton) ?? false,
                HideDisastersButton = (file_1_19?.HideDisastersButton) ?? (file_1_17?.HideDisastersButton) ?? false,
                HideChirperButton = (file_1_19?.HideChirperButton) ?? (file_1_17?.HideChirperButton) ?? false,
                HideRadioButton = (file_1_19?.HideRadioButton) ?? (file_1_17?.HideRadioButton) ?? false,
                HideGearButton = (file_1_19?.HideGearButton) ?? (file_1_17?.HideGearButton) ?? false,
                HideZoomButton = (file_1_19?.HideZoomButton) ?? (file_1_17?.HideZoomButton) ?? false,
                HideUnlockButton = (file_1_19?.HideUnlockButton) ?? (file_1_17?.HideUnlockButton) ?? false,
                HideAdvisorButton = (file_1_19?.HideAdvisorButton) ?? (file_1_17?.HideAdvisorButton) ?? false,
                HideBulldozerButton = (file_1_19?.HideBulldozerButton) ?? (file_1_17?.HideBulldozerButton) ?? false,
                HideCinematicCameraButton = (file_1_19?.HideCinematicCameraButton) ?? (file_1_17?.HideCinematicCameraButton) ?? false,
                HideFreeCameraButton = (file_1_19?.HideFreeCameraButton) ?? (file_1_17?.HideFreeCameraButton) ?? false,
                HideCongratulationPanel = (file_1_19?.HideCongratulationPanel) ?? (file_1_17?.HideCongratulationPanel) ?? false,
                HideAdvisorPanel = (file_1_19?.HideAdvisorPanel) ?? (file_1_17?.HideAdvisorPanel) ?? false,
                HideTimePanel = (file_1_19?.HideTimePanel) ?? (file_1_17?.HideTimePanel) ?? false,
                HideZoomAndUnlockBackground = (file_1_19?.HideZoomAndUnlockBackground) ?? (file_1_17?.HideZoomAndUnlockBackground) ?? false,
                HideSeparators = (file_1_19?.HideSeparators) ?? (file_1_17?.HideSeparators) ?? false,
                HideCityName = false,
                HidePauseOutline = false,
                HideBulldozerBar = false,
                HideThermometer = false,
                ModifyToolbarPosition = false,
                ToolbarPosition = 0f,
                #endregion
            };

            Provider_1_21.Save(file_1_21);
            Provider_1_19.Delete();
        }
    }
}