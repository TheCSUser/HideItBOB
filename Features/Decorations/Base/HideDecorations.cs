using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.Shared.Checks;
using com.github.TheCSUser.Shared.Common;
using System;

namespace com.github.TheCSUser.HideItBobby.Features.Decorations
{
    internal abstract class HideDecorations : UpdatableFeatureBase
    {
        protected TerrainProperties TerrainProperties => TerrainManager.exists ? TerrainManager.instance.m_properties : null;
        protected readonly ModCheck ThemeMixer2;

        protected bool? DefaultValue;
        protected abstract bool PropertyValue { get; set; }

        public HideDecorations(IModContext context) : base(context)
        {
            ThemeMixer2 = context.Resolve<ModCheck>(Mods.ThemeMixer2);
        }

        public override FeatureFlags Update()
        {
            if (IsDisposed || IsError || !IsAvailable || !IsInitialized) return Result(false);
            try
            {
                if (ThemeMixer2.IsEnabled && !Mod.Settings.OverrideThemeMixer2)
                {
                    if (IsEnabled) return Disable();
                    return Result(true);
                }
                else
                {
                    var result = OnUpdate();
                    return Result(result, true);
                }
            }
            catch (Exception e)
            {
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(OnUpdate)} failed", e);
                return Result(false);
            }
        }

        protected override bool OnEnable()
        {
            if (ThemeMixer2.IsEnabled && !Mod.Settings.OverrideThemeMixer2) return false;
            return OnUpdate();
        }
        protected override bool OnDisable()
        {
            if (TerrainProperties is null)
            {
#if DEV
                Log.Info($"{GetType().Name}.{nameof(OnDisable)} {nameof(TerrainProperties)} is null");
#endif
                return false;
            }
            if (DefaultValue.HasValue)
            {
                PropertyValue = DefaultValue.Value;
                DefaultValue = null;
            }
            return true;
        }
        protected override bool OnUpdate()
        {
            if (TerrainProperties is null)
            {
#if DEV
                Log.Info($"{GetType().Name}.{nameof(OnUpdate)} {nameof(TerrainProperties)} is null");
#endif
                return false;
            }
            if (!DefaultValue.HasValue)
            {
                DefaultValue = PropertyValue;
            }
            PropertyValue = !IsEnabled;
            return true;
        }
    }
}