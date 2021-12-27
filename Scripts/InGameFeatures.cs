using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.HideItBobby.Features.Decorations;
using com.github.TheCSUser.HideItBobby.Features.Effects;
using com.github.TheCSUser.HideItBobby.Features.Effects.Shared;
using com.github.TheCSUser.HideItBobby.Features.Fixes;
using com.github.TheCSUser.HideItBobby.Features.GroundAndWaterColor;
using com.github.TheCSUser.HideItBobby.Features.Objects;
using com.github.TheCSUser.HideItBobby.Features.Problems;
using com.github.TheCSUser.HideItBobby.Features.Ruining;
using com.github.TheCSUser.HideItBobby.Features.UIElements;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.Shared.Checks;
using System;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal sealed class InGameFeatures : FeaturesScript
    {
        #region Features
        private static IFeaturesContainer GetFeatures(Mod mod)
        {
            try
            {
                var themeMixer2 = mod.Context.Resolve<ModCheck>(Mods.ThemeMixer2);

                return new FeaturesContainer(mod.Context)
                //Decorations
                .Register(new HideCliffDecorations(mod.Context), () => mod.Settings.HideCliffDecorations && (themeMixer2.IsDisabled || mod.Settings.OverrideThemeMixer2))
                .Register(new HideFertileDecorations(mod.Context), () => mod.Settings.HideFertileDecorations && (themeMixer2.IsDisabled || mod.Settings.OverrideThemeMixer2))
                .Register(new HideGrassDecorations(mod.Context), () => mod.Settings.HideGrassDecorations && (themeMixer2.IsDisabled || mod.Settings.OverrideThemeMixer2))
                //Effects
                .Register(new HideOreAreaEffect(mod.Context), () => mod.Settings.HideOreArea)
                .Register(new HideOilAreaEffect(mod.Context), () => mod.Settings.HideOilArea)
                .Register(new HideSandAreaEffect(mod.Context), () => mod.Settings.HideSandArea)
                .Register(new HideFertilityAreaEffect(mod.Context), () => mod.Settings.HideFertilityArea)
                .Register(new HideForestAreaEffect(mod.Context), () => mod.Settings.HideForestArea)
                .Register(new HideShoreAreaEffect(mod.Context), () => mod.Settings.HideShoreArea)
                .Register(new HidePollutedAreaEffect(mod.Context), () => mod.Settings.HidePollutedArea)
                .Register(new HideBurnedAreaEffect(mod.Context), () => mod.Settings.HideBurnedArea)
                .Register(new HideDestroyedAreaEffect(mod.Context), () => mod.Settings.HideDestroyedArea)
                .Register(new HideDistanceFog(mod.Context), () => mod.Settings.HideDistanceFog)
                .Register(new HideEdgeFog(mod.Context), () => mod.Settings.HideEdgeFog)
                .Register(new HidePollutionFog(mod.Context), () => mod.Settings.HidePollutionFog)
                .Register(new HideVolumeFog(mod.Context), () => mod.Settings.HideVolumeFog)
                .Register(new DisablePlacementEffect(mod.Context), () => mod.Settings.DisablePlacementEffect)
                .Register(new DisableBulldozingEffect(mod.Context), () => mod.Settings.DisableBulldozingEffect)
                //GroundAndWaterColor
                .Register(new DisableDirtyWaterColor(mod.Context), () => mod.Settings.DisableDirtyWaterColor)
                .Register(new DisableGrassFertilityGroundColor(mod.Context), () => mod.Settings.DisableGrassFertilityGroundColor)
                .Register(new DisableGrassFieldGroundColor(mod.Context), () => mod.Settings.DisableGrassFieldGroundColor)
                .Register(new DisableGrassForestGroundColor(mod.Context), () => mod.Settings.DisableGrassForestGroundColor)
                .Register(new DisableGrassPollutionGroundColor(mod.Context), () => mod.Settings.DisableGrassPollutionGroundColor)
                //Objects
                .Register(new HideSeagulls(mod.Context), () => mod.Settings.HideSeagulls)
                .Register(new HideWildlife(mod.Context), () => mod.Settings.HideWildlife)
                //Ruining
                .Register(new HideTreeRuining(mod.Context), () => mod.Settings.HideTreeRuining)
                .Register(new HidePropRuining(mod.Context), () => mod.Settings.HidePropRuining)
                //UIElements
                .Register(new HideAdvisorButton(mod.Context), () => mod.Settings.HideAdvisorButton)
                .Register(new HideBulldozerButton(mod.Context), () => mod.Settings.HideBulldozerButton)
                .Register(new HideChirperButton(mod.Context), () => mod.Settings.HideChirperButton)
                .Register(new HideCinematicCameraButton(mod.Context), () => mod.Settings.HideCinematicCameraButton)
                .Register(new HideCityName(mod.Context), () => mod.Settings.HideCityName)
                .Register(new CityNamePosition(mod.Context), () => mod.Settings.ModifyCityNamePosition)
                .Register(new HideDisastersButton(mod.Context), () => mod.Settings.HideDisastersButton)
                .Register(new HideFreeCameraButton(mod.Context), () => mod.Settings.HideFreeCameraButton)
                .Register(new HideGearButton(mod.Context), () => mod.Settings.HideGearButton)
                .Register(new HideInfoViewsButton(mod.Context), () => mod.Settings.HideInfoViewsButton)
                .Register(new HideRadioButton(mod.Context), () => mod.Settings.HideRadioButton)
                .Register(new HideSeparators(mod.Context), () => mod.Settings.HideSeparators)
                .Register(new HideTimePanel(mod.Context), () => mod.Settings.HideTimePanel)
                .Register(new HideUnlockButton(mod.Context), () => mod.Settings.HideUnlockButton)
                .Register(new HideZoomAndUnlockBackground(mod.Context), () => mod.Settings.HideZoomAndUnlockBackground)
                .Register(new HideZoomButton(mod.Context), () => mod.Settings.HideZoomButton)
                .Register(new HideCongratulationPanel(mod.Context), () => mod.Settings.HideCongratulationPanel)
                .Register(new HideAdvisorPanel(mod.Context), () => mod.Settings.HideAdvisorPanel)
                .Register(new HidePauseOutline(mod.Context), () => mod.Settings.HidePauseOutline)
                .Register(new HideBulldozerBar(mod.Context), () => mod.Settings.HideBulldozerBar)
                .Register(new HideThermometer(mod.Context), () => mod.Settings.HideThermometer)
                .Register(new ToolbarPosition(mod.Context), () => mod.Settings.ModifyToolbarPosition)
                .Register(new HideNetworksCursorInfo(mod.Context), () => mod.Settings.HideNetworksCursorInfo)
                .Register(new HideBuildingsCursorInfo(mod.Context), () => mod.Settings.HideBuildingsCursorInfo)
                .Register(new HideTreesCursorInfo(mod.Context), () => mod.Settings.HideTreesCursorInfo)
                .Register(new HidePropsCursorInfo(mod.Context), () => mod.Settings.HidePropsCursorInfo)
                //Problems
                .Register(new HideTerraformNetworkFloodNotification(mod.Context), () => mod.Settings.HideTerraformNetworkFloodNotification)
                .Register(new HideDisconnectedPowerLinesNotification(mod.Context), () => mod.Settings.HideDisconnectedPowerLinesNotification)
                //Fixes
                .Register(new LowerInfoPanelZOrder(mod.Context), () => true)
                ;
            }
            catch (Exception e)
            {
                mod.Context.Log.Error($"{nameof(InGameFeatures)}.{nameof(GetFeatures)} failed", e);
                return FeaturesContainer.Empty;
            }
        }
        #endregion

        protected override string Name => $"{ModProperties.ShortName}.{nameof(InGameFeatures)}";

        private readonly InfoViewUpdater InfoViewUpdater;
        private readonly TexturesUpdater TexturesUpdater;

        public InGameFeatures(Mod mod) : base(mod, GetFeatures(mod))
        {
            InfoViewUpdater = new InfoViewUpdater(mod.Context);
            TexturesUpdater = new TexturesUpdater(mod.Context);
        }

        protected override bool OnUpdate()
        {
            var result = base.OnUpdate();
            InfoViewUpdater.Update();
            TexturesUpdater.Update(Mod.Settings.VersionCounter);
            return result;
        }
    }
}