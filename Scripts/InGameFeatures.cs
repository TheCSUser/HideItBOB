using com.github.TheCSUser.HideItBobby.Features;
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
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal sealed class InGameFeatures : FeaturesScript
    {
        #region Features
        private static IFeaturesContainer GetFeatures(IModContext context) => new FeaturesContainer(context)
            //Decorations
            .Register(new HideCliffDecorations(context))
            .Register(new HideFertileDecorations(context))
            .Register(new HideGrassDecorations(context))
            //Effects
            .Register(new HideOreAreaEffect(context))
            .Register(new HideOilAreaEffect(context))
            .Register(new HideSandAreaEffect(context))
            .Register(new HideFertilityAreaEffect(context))
            .Register(new HideForestAreaEffect(context))
            .Register(new HideShoreAreaEffect(context))
            .Register(new HidePollutedAreaEffect(context))
            .Register(new HideBurnedAreaEffect(context))
            .Register(new HideDestroyedAreaEffect(context))
            .Register(new HideDistanceFog(context))
            .Register(new HideEdgeFog(context))
            .Register(new HidePollutionFog(context))
            .Register(new HideVolumeFog(context))
            .Register(new DisablePlacementEffect(context))
            .Register(new DisableBulldozingEffect(context))
            //GroundAndWaterColor
            .Register(new DisableDirtyWaterColor(context))
            .Register(new DisableGrassFertilityGroundColor(context))
            .Register(new DisableGrassFieldGroundColor(context))
            .Register(new DisableGrassForestGroundColor(context))
            .Register(new DisableGrassPollutionGroundColor(context))
            //Objects
            .Register(new HideSeagulls(context))
            .Register(new HideWildlife(context))
            //Ruining
            .Register(new HideTreeRuining(context))
            .Register(new HidePropRuining(context))
            //UIElements
            .Register(new HideAdvisorButton(context))
            .Register(new HideBulldozerButton(context))
            .Register(new HideChirperButton(context))
            .Register(new HideCinematicCameraButton(context))
            .Register(new HideCityName(context))
            .Register(new HideDisastersButton(context))
            .Register(new HideFreeCameraButton(context))
            .Register(new HideGearButton(context))
            .Register(new HideInfoViewsButton(context))
            .Register(new HideRadioButton(context))
            .Register(new HideSeparators(context))
            .Register(new HideTimePanel(context))
            .Register(new HideUnlockButton(context))
            .Register(new HideZoomAndUnlockBackground(context))
            .Register(new HideZoomButton(context))
            .Register(new HideCongratulationPanel(context))
            .Register(new HideAdvisorPanel(context))
            .Register(new HidePauseOutline(context))
            .Register(new HideBulldozerBar(context))
            .Register(new HideThermometer(context))
            .Register(new ToolbarPosition(context))
            //Problems
            .Register(new HideTerraformNetworkFloodNotification(context))
            .Register(new HideDisconnectedPowerLinesNotification(context))
            //Fixes
            .Register(new LowerInfoPanelZOrder(context))
            ;
        #endregion
        #region Settings
        private static ISettingsContainer GetSettings(Mod mod)
        {
            return new SettingsContainer(mod.Context)
                //Decorations
                .Register(FeatureKey.HideCliffDecorations, () => mod.Settings.HideCliffDecorations)
                .Register(FeatureKey.HideFertileDecorations, () => mod.Settings.HideFertileDecorations)
                .Register(FeatureKey.HideGrassDecorations, () => mod.Settings.HideGrassDecorations)
                //Effects
                .Register(FeatureKey.HideOreAreaEffect, () => mod.Settings.HideOreArea)
                .Register(FeatureKey.HideOilAreaEffect, () => mod.Settings.HideOilArea)
                .Register(FeatureKey.HideSandAreaEffect, () => mod.Settings.HideSandArea)
                .Register(FeatureKey.HideFertilityAreaEffect, () => mod.Settings.HideFertilityArea)
                .Register(FeatureKey.HideForestAreaEffect, () => mod.Settings.HideForestArea)
                .Register(FeatureKey.HideShoreAreaEffect, () => mod.Settings.HideShoreArea)
                .Register(FeatureKey.HidePollutedAreaEffect, () => mod.Settings.HidePollutedArea)
                .Register(FeatureKey.HideBurnedAreaEffect, () => mod.Settings.HideBurnedArea)
                .Register(FeatureKey.HideDestroyedAreaEffect, () => mod.Settings.HideDestroyedArea)
                .Register(FeatureKey.HideDistanceFog, () => mod.Settings.HideDistanceFog)
                .Register(FeatureKey.HideEdgeFog, () => mod.Settings.HideEdgeFog)
                .Register(FeatureKey.HidePollutionFog, () => mod.Settings.HidePollutionFog)
                .Register(FeatureKey.HideVolumeFog, () => mod.Settings.HideVolumeFog)
                .Register(FeatureKey.DisablePlacementEffect, () => mod.Settings.DisablePlacementEffect)
                .Register(FeatureKey.DisableBulldozingEffect, () => mod.Settings.DisableBulldozingEffect)
                //GroundAndWaterColor
                .Register(FeatureKey.DisableDirtyWaterColor, () => mod.Settings.DisableDirtyWaterColor)
                .Register(FeatureKey.DisableGrassFertilityGroundColor, () => mod.Settings.DisableGrassFertilityGroundColor)
                .Register(FeatureKey.DisableGrassFieldGroundColor, () => mod.Settings.DisableGrassFieldGroundColor)
                .Register(FeatureKey.DisableGrassForestGroundColor, () => mod.Settings.DisableGrassForestGroundColor)
                .Register(FeatureKey.DisableGrassPollutionGroundColor, () => mod.Settings.DisableGrassPollutionGroundColor)
                //Objects
                .Register(FeatureKey.HideSeagulls, () => mod.Settings.HideSeagulls)
                .Register(FeatureKey.HideWildlife, () => mod.Settings.HideWildlife)
                //Ruining
                .Register(FeatureKey.HideTreeRuining, () => mod.Settings.HideTreeRuining)
                .Register(FeatureKey.HidePropRuining, () => mod.Settings.HidePropRuining)
                //UIElements
                .Register(FeatureKey.HideAdvisorButton, () => mod.Settings.HideAdvisorButton)
                .Register(FeatureKey.HideBulldozerButton, () => mod.Settings.HideBulldozerButton)
                .Register(FeatureKey.HideChirperButton, () => mod.Settings.HideChirperButton)
                .Register(FeatureKey.HideCinematicCameraButton, () => mod.Settings.HideCinematicCameraButton)
                .Register(FeatureKey.HideCityName, () => mod.Settings.HideCityName)
                .Register(FeatureKey.HideDisastersButton, () => mod.Settings.HideDisastersButton)
                .Register(FeatureKey.HideFreeCameraButton, () => mod.Settings.HideFreeCameraButton)
                .Register(FeatureKey.HideGearButton, () => mod.Settings.HideGearButton)
                .Register(FeatureKey.HideInfoViewsButton, () => mod.Settings.HideInfoViewsButton)
                .Register(FeatureKey.HideRadioButton, () => mod.Settings.HideRadioButton)
                .Register(FeatureKey.HideSeparators, () => mod.Settings.HideSeparators)
                .Register(FeatureKey.HideTimePanel, () => mod.Settings.HideTimePanel)
                .Register(FeatureKey.HideUnlockButton, () => mod.Settings.HideUnlockButton)
                .Register(FeatureKey.HideZoomAndUnlockBackground, () => mod.Settings.HideZoomAndUnlockBackground)
                .Register(FeatureKey.HideZoomButton, () => mod.Settings.HideZoomButton)
                .Register(FeatureKey.HideCongratulationPanel, () => mod.Settings.HideCongratulationPanel)
                .Register(FeatureKey.HideAdvisorPanel, () => mod.Settings.HideAdvisorPanel)
                .Register(FeatureKey.HidePauseOutline, () => mod.Settings.HidePauseOutline)
                .Register(FeatureKey.HideBulldozerBar, () => mod.Settings.HideBulldozerBar)
                .Register(FeatureKey.HideThermometer, () => mod.Settings.HideThermometer)
                .Register(FeatureKey.ToolbarPosition, () => mod.Settings.ModifyToolbarPosition)
                //Problems
                .Register(FeatureKey.HideTerraformNetworkFloodNotification, () => mod.Settings.HideTerraformNetworkFloodNotification)
                .Register(FeatureKey.HideDisconnectedPowerLinesNotification, () => mod.Settings.HideDisconnectedPowerLinesNotification)
                //Fixes
                .Register(FeatureKey.LowerInfoPanelZOrder, () => true)
                ;
        }
        #endregion

        protected override string Name => $"{ModProperties.ShortName}.{nameof(InGameFeatures)}";

        private readonly InfoViewUpdater InfoViewUpdater;
        private readonly TexturesUpdater TexturesUpdater;

        public InGameFeatures(Mod mod) : base(mod, GetFeatures(mod.Context), GetSettings(mod))
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