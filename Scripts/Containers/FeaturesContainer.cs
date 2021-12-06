using com.github.TheCSUser.HideItBobby.Features;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal sealed class FeaturesContainer : WithContext, IFeaturesContainer
    {
        public static readonly IFeaturesContainer Empty = new EmptyFeaturesContainer();

        private readonly Dictionary<FeatureKey, IFeature> _features = new Dictionary<FeatureKey, IFeature>();
        private readonly Dictionary<FeatureKey, Func<bool>> _settings = new Dictionary<FeatureKey, Func<bool>>();

        public int Count => _features.Count;

        public FeaturesContainer(IModContext context) : base(context) { }

        public FeaturesContainer Register(IFeature feature, Func<bool> isEnabled)
        {
            if (_features.TryGetValue(feature.Key, out IFeature existingFeature))
            {
#if DEV
                Log.Warning($"{nameof(FeaturesContainer)}.{nameof(Resolve)} feature {feature.Key} registered twice");
#endif
                if (existingFeature is IDisposable disposable) disposable.Dispose();
            }
            _features[feature.Key] = feature;
            _settings[feature.Key] = isEnabled;
            return this;
        }
        IFeaturesContainer IFeaturesContainer.Register(IFeature feature, Func<bool> isEnabled) => Register(feature, isEnabled);

        public IFeature Resolve(FeatureKey key)
        {
            if (_features.TryGetValue(key, out IFeature feature)) return feature;
#if DEV
            Log.Warning($"{nameof(FeaturesContainer)}.{nameof(Resolve)} trying to resolve missing feature {key}");
#endif
            return null;
        }

        public bool IsSettingEnabled(FeatureKey key)
        {
            if (!_settings.TryGetValue(key, out Func<bool> function))
            {
#if DEV
                Log.Warning($"{nameof(FeaturesContainer)}.{nameof(IsSettingEnabled)} trying to resolve missing feature settings {key}");
#endif
                return false;
            }
            if (function is null)
            {
#if DEV
                Log.Warning($"{nameof(FeaturesContainer)}.{nameof(IsSettingEnabled)} settings function for {key} is null");
#endif
                return false;
            }
            return function();
        }

        public void Clear()
        {
            _features.Clear();
            _settings.Clear();
        }

        #region Enumerable
        public IEnumerator<IFeature> GetEnumerator() => _features.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _features.Values.GetEnumerator();
        #endregion

        #region EmptyFeaturesContainer
        private sealed class EmptyFeaturesContainer : IFeaturesContainer
        {
            public int Count => 0;

            public FeaturesContainer Register(IFeature feature, Func<bool> isEnabled) => new FeaturesContainer(feature.Context).Register(feature, isEnabled);
            IFeaturesContainer IFeaturesContainer.Register(IFeature feature, Func<bool> isEnabled) => Register(feature, isEnabled);

            public IFeature Resolve(FeatureKey key) => null;

            public bool IsSettingEnabled(FeatureKey key) => false;

            public void Clear() { }

            #region Enumerable
            public IEnumerator<IFeature> GetEnumerator() => Enumerable.Empty<IFeature>().GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => Enumerable.Empty<IFeature>().GetEnumerator();
            #endregion
        }
        #endregion
    }
}