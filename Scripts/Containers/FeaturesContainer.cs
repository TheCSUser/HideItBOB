using com.github.TheCSUser.HideItBobby.Features;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal sealed class FeaturesContainer : Dictionary<FeatureKey, IFeature>, IFeaturesContainer
    {
        private readonly IModContext _context;
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used in DEV build")]
        private ILogger Log => _context.Log;

        public FeaturesContainer(IModContext context) : base()
        {
            _context = context;
        }

        public FeaturesContainer Register(IFeature feature)
        {
            if (TryGetValue(feature.Key, out IFeature existingFeature))
            {
#if DEV
                Log.Warning($"{nameof(FeaturesContainer)}.{nameof(Resolve)} feature {feature.Key} registered twice");
#endif
                if (existingFeature is IDisposable disposable) disposable.Dispose();
            }
            this[feature.Key] = feature;
            return this;
        }
        IFeaturesContainer IFeaturesContainer.Register(IFeature feature) => Register(feature);

        public IFeature Resolve(FeatureKey key)
        {
            if (TryGetValue(key, out IFeature feature)) return feature;
#if DEV
            Log.Warning($"{nameof(FeaturesContainer)}.{nameof(Resolve)} trying to resolve missing feature {key}");
#endif
            return null;
        }
    }
}