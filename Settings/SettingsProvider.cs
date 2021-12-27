using com.github.TheCSUser.HideItBobby.Settings.Providers;
using System;
using com.github.TheCSUser.Shared.Settings;
using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Imports;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Settings
{
    using File = File_1_21;
    using Provider = Provider_1_21;

    internal sealed class SettingsProvider : WithContext, ISettingsReaderWriter<File>
    {
        private readonly Provider Provider;

        public string FileName => Provider.FileName;

        public SettingsProvider(IModContext context) : base(context)
        {
            Provider = new Provider(context);
            SaveAction = new SlidingDelayAction<File>(Provider.Save);
        }

        #region Save()
        private readonly Action<File> SaveAction;

        public void Save(File settingsFile)
        {
            if (settingsFile is null)
            {
#if DEV
                Log.Warning($"{nameof(SettingsProvider)}.{nameof(Save)} nothing to save");
#endif
                return;
            }

            SaveAction(settingsFile);
        }

        void ISettingsWriter.Save(ISettings data) => Save(data as File);
        #endregion

        #region Load()
        public File Load()
        {
#if DEV
            Log.Info($"{nameof(SettingsProvider)}.{nameof(Load)} loading settings");
#endif
            try
            {

                var file = Provider.Load();
#if DEV
                Log.Info($"{nameof(SettingsProvider)}.{nameof(Load)} {nameof(file)} deserialized content");
                Log.Info(ObjectDumper.Dump(file));
#endif
                if (!(file is null)) return file;

                var _data = Default();
                Provider.Save(_data);
                return _data;
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(SettingsProvider)}.{nameof(Load)} failed", e);
                return Default();
            }
        }

        private File Default() => new File
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
            HideCliffDecorations = false,
            HideFertileDecorations = false,
            HideGrassDecorations = false,

            //Effects
            HideOreArea = false,
            HideOilArea = false,
            HideSandArea = false,
            HideFertilityArea = false,
            HideForestArea = false,
            HideShoreArea = false,
            HidePollutedArea = false,
            HideBurnedArea = false,
            HideDestroyedArea = false,
            HidePollutionFog = false,
            HideVolumeFog = false,
            HideDistanceFog = false,
            HideEdgeFog = false,
            DisableBulldozingEffect = false,
            DisablePlacementEffect = false,

            //Ground and water color
            DisableGrassFertilityGroundColor = false,
            DisableGrassFieldGroundColor = false,
            DisableGrassForestGroundColor = false,
            DisableGrassPollutionGroundColor = false,
            DisableDirtyWaterColor = false,

            //Objects
            HideSeagulls = false,
            HideWildlife = false,

            //Ruining - Deprecated
            HideTreeRuining = false,
            HidePropRuining = false,

            //In game ui elements
            HideInfoViewsButton = false,
            HideDisastersButton = false,
            HideChirperButton = false,
            HideRadioButton = false,
            HideGearButton = false,
            HideZoomButton = false,
            HideUnlockButton = false,
            HideAdvisorButton = false,
            HideBulldozerButton = false,
            HideCinematicCameraButton = false,
            HideFreeCameraButton = false,
            HideCongratulationPanel = false,
            HideAdvisorPanel = false,
            HideTimePanel = false,
            HideZoomAndUnlockBackground = false,
            HideSeparators = false,
            HideCityName = false,
            ModifyCityNamePosition = false,
            CityNamePosition = 0f,
            HidePauseOutline = false,
            HideBulldozerBar = false,
            HideThermometer = false,
            ModifyToolbarPosition = false,
            ToolbarPosition = 0f,
            HideBuildingsCursorInfo = false,
            HideNetworksCursorInfo = false,
            HidePropsCursorInfo = false,
            HideTreesCursorInfo = false,

            //Problems
            HideTerraformNetworkFloodNotification = true,
            HideDisconnectedPowerLinesNotification = false,
            #endregion
        };

        ISettings ISettingsReader.Load() => Load();
        #endregion

        public void Delete() => Provider.Delete();
    }
}