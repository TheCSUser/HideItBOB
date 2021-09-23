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

    internal class Migrate_1_20_to_1_21 : Migration
    {
        private readonly Provider_1_19 Provider_1_19;
        private readonly Provider_1_21 Provider_1_21;

        public Migrate_1_20_to_1_21(IModContext context) : base(context)
        {
            Provider_1_19 = new Provider_1_19(context);
            Provider_1_21 = new Provider_1_21(context);
        }

        public override void Migrate()
        {
            if (Exists(File_1_21)) return;

            var file_1_19 = Provider_1_19.Load();
            if (file_1_19 is null) return;

#if DEV
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
                HideCliffDecorations = (file_1_19?.HideCliffDecorations) ?? false,
                HideFertileDecorations = (file_1_19?.HideFertileDecorations) ?? false,
                HideGrassDecorations = (file_1_19?.HideGrassDecorations) ?? false,

                //Effects
                HideOreArea = (file_1_19?.HideOreArea) ?? false,
                HideOilArea = (file_1_19?.HideOilArea) ?? false,
                HideSandArea = (file_1_19?.HideSandArea) ?? false,
                HideFertilityArea = (file_1_19?.HideFertilityArea) ?? false,
                HideForestArea = (file_1_19?.HideForestArea) ?? false,
                HideShoreArea = (file_1_19?.HideShoreArea) ?? false,
                HidePollutedArea = (file_1_19?.HidePollutedArea) ?? false,
                HideBurnedArea = (file_1_19?.HideBurnedArea) ?? false,
                HideDestroyedArea = (file_1_19?.HideDestroyedArea) ?? false,
                HidePollutionFog = (file_1_19?.HidePollutionFog) ?? false,
                HideVolumeFog = (file_1_19?.HideVolumeFog) ?? false,
                HideDistanceFog = (file_1_19?.HideDistanceFog) ?? false,
                HideEdgeFog = (file_1_19?.HideEdgeFog) ?? false,

                //Ground and water color
                DisableGrassFertilityGroundColor = (file_1_19?.DisableGrassFertilityGroundColor) ?? false,
                DisableGrassFieldGroundColor = (file_1_19?.DisableGrassFieldGroundColor) ?? false,
                DisableGrassForestGroundColor = (file_1_19?.DisableGrassForestGroundColor) ?? false,
                DisableGrassPollutionGroundColor = (file_1_19?.DisableGrassPollutionGroundColor) ?? false,
                DisableDirtyWaterColor = (file_1_19?.DisableDirtyWaterColor) ?? false,

                //Objects
                HideSeagulls = (file_1_19?.HideSeagulls) ?? false,
                HideWildlife = (file_1_19?.HideWildlife) ?? false,

                //Ruining - Deprecated
                HideTreeRuining = false,
                HidePropRuining = false,

                //In game ui elements
                HideInfoViewsButton = (file_1_19?.HideInfoViewsButton) ?? false,
                HideDisastersButton = (file_1_19?.HideDisastersButton) ?? false,
                HideChirperButton = (file_1_19?.HideChirperButton) ?? false,
                HideRadioButton = (file_1_19?.HideRadioButton) ?? false,
                HideGearButton = (file_1_19?.HideGearButton) ?? false,
                HideZoomButton = (file_1_19?.HideZoomButton) ?? false,
                HideUnlockButton = (file_1_19?.HideUnlockButton) ?? false,
                HideAdvisorButton = (file_1_19?.HideAdvisorButton) ?? false,
                HideBulldozerButton = (file_1_19?.HideBulldozerButton) ?? false,
                HideCinematicCameraButton = (file_1_19?.HideCinematicCameraButton) ?? false,
                HideFreeCameraButton = (file_1_19?.HideFreeCameraButton) ?? false,
                HideCongratulationPanel = (file_1_19?.HideCongratulationPanel) ?? false,
                HideAdvisorPanel = (file_1_19?.HideAdvisorPanel) ?? false,
                HideTimePanel = (file_1_19?.HideTimePanel) ?? false,
                HideZoomAndUnlockBackground = (file_1_19?.HideZoomAndUnlockBackground) ?? false,
                HideSeparators = (file_1_19?.HideSeparators) ?? false,
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