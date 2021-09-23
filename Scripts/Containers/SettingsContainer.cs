using com.github.TheCSUser.HideItBobby.Features;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal sealed class SettingsContainer : Dictionary<FeatureKey, Func<bool>>, ISettingsContainer
    {
        private readonly IModContext _context;

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used in DEV build")]
        private ILogger Log => _context.Log;

        public SettingsContainer(IModContext context) : base()
        {
            _context = context;
        }

        public SettingsContainer Register(FeatureKey key, Func<bool> function)
        {
            this[key] = function;
            return this;
        }
        ISettingsContainer ISettingsContainer.Register(FeatureKey key, Func<bool> function) => Register(key, function);

        public Func<bool> Resolve(FeatureKey key)
        {
            if (TryGetValue(key, out Func<bool> function)) return function;
#if DEV
            Log.Warning($"{nameof(SettingsContainer)}.{nameof(Resolve)} trying to resolve missing feature settings {key}");
#endif
            return null;
        }

        public bool Get(FeatureKey key)
        {
            var function = Resolve(key);
            if (function is null) return false;
            return function();
        }
    }
}