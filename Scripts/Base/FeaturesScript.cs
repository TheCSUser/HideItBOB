using com.github.TheCSUser.HideItBobby.Features;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Linq;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal abstract class FeaturesScript : ScriptBase
    {
        private Counter _appliedSettings = int.MaxValue;

        protected Mod Mod { get; }

        public virtual IFeaturesContainer Features { get; }
        public virtual ISettingsContainer Settings { get; }

        public FeaturesScript(Mod mod, IFeaturesContainer features, ISettingsContainer settings) : base(mod.Context)
        {
            _lifecycleManager = new LifecycleManager(this);
            Mod = mod;
            Features = features;
            Settings = settings;
        }

        protected override bool OnEnable()
        {
#if DEV
            Log.Info($"{GetType().Name} enabling");
#endif
            foreach (var feature in Features.Values)
                feature.IsError = false;

            var success = true;
            foreach (var feature in Features.Values)
            {
                var shouldBeEnabled = Settings.Get(feature.Key);

                if (feature.IsEnabled == shouldBeEnabled) continue;

                var flags = shouldBeEnabled ? feature.Enable() : feature.Disable();
#if DEV
                if (flags.ErrorCount > 0 || !flags) Log.Info($"{GetType().Name}.{nameof(OnEnable)} {feature.Key} flags: {flags}");
#endif
                if (flags.IsAvailable && !flags.IsError && flags.Executed
                    && (!flags.EndResult || flags.ErrorCount > 0))
                {
                    success = false;
                }
            }
            if (success) _appliedSettings = Mod.Settings.VersionCounter.Clone();

            return success;
        }
        protected override bool OnDisable()
        {
#if DEV
            Log.Info($"{GetType().Name} disabling");
#endif
            foreach (var feature in Features.Values.Reverse())
            {
                if (!feature.IsEnabled) continue;

                var flags = feature.Disable();
#if DEV
                if (flags.ErrorCount > 0 || !flags) Log.Info($"{GetType().Name}.{nameof(OnDisable)} {feature.Key} flags: {flags}");
#endif
            }
            return true;
        }
        public override bool Update()
        {
            if (!IsEnabled) return true;
            try
            {
                return OnUpdate();
            }
            catch (Exception e)
            {
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(OnUpdate)} failed", e);
                return false;
            }
        }
        protected override bool OnUpdate()
        {
            if (Mod.Settings.VersionCounter > _appliedSettings)
            {
                try
                {
                    var success = true;
                    foreach (var feature in Features.Values)
                    {
                        var shouldBeEnabled = Settings.Get(feature.Key);
                        if (feature.IsEnabled == shouldBeEnabled) continue;

                        var flags = shouldBeEnabled ? feature.Enable() : feature.Disable();
#if DEV
                        if (flags.ErrorCount > 0 || !flags) Log.Info($"{GetType().Name}.{nameof(OnUpdate)} {feature.Key} flags: {flags}");
#endif
                        if (flags.IsAvailable && !flags.IsError && flags.Executed
                            && (!flags.EndResult || flags.ErrorCount > 0))
                        {
                            success = false;
                        }
                    }
                    if (success) _appliedSettings = Mod.Settings.VersionCounter.Clone();
                }
                catch (Exception e)
                {
                    Log.Error($"{GetType().Name}.{nameof(OnUpdate)} failed", e);
                }
            }

            try
            {
                foreach (var feature in Features.Values.Where(f => f is IUpdatableFeature).Cast<IUpdatableFeature>())
                {
                    var flags = feature.Update();
#if DEV
                    if (flags.ErrorCount > 0 || !flags) Log.Info($"{GetType().Name}.{nameof(OnUpdate)} {feature.Key} flags: {flags}");
#endif
                }
            }
            catch (Exception e)
            {
                Log.Error($"{GetType().Name}.{nameof(OnUpdate)} failed", e);
            }

            return true;
        }

        #region Lifecycle
        public sealed override IInitializable GetLifecycleManager() => _lifecycleManager;
        private readonly LifecycleManager _lifecycleManager;

        private class LifecycleManager : Shared.Common.LifecycleManager
        {
            private readonly FeaturesScript Script;
            public LifecycleManager(FeaturesScript script) : base(((IWithContext)script).Context)
            {
                Script = script;
            }

            protected override bool OnInitialize()
            {
#if DEV
                Log.Info($"{Script.GetType().Name}.{GetType().Name} initializing");
#endif
                foreach (var feature in Script.Features.Values)
                {
                    feature.IsError = false;
                    feature.Initialize();
                }
                return true;
            }

            protected override bool OnTerminate()
            {
#if DEV
                Log.Info($"{Script.GetType().Name}.{GetType().Name} terminating");
#endif
                foreach (var feature in Script.Features.Values.Reverse())
                    feature.Terminate();
                return true;
            }
        }
        #endregion

        #region ThrottledUpdater
        protected override ScriptUpdater AddUpdaterComponent(GameObject parent) => parent.AddComponent<ThrottledUpdater>();

        internal sealed class ThrottledUpdater : ScriptUpdater
        {
            private const byte THROTTLE_BY = 10;
            private byte _counter = 0;

            protected override void OnUpdate()
            {
                if (++_counter % THROTTLE_BY != 0) return;
                base.OnUpdate();
            }
        } 
        #endregion
    }
}