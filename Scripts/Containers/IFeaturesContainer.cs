using com.github.TheCSUser.HideItBobby.Features;
using System;
using System.Collections.Generic;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal interface IFeaturesContainer : IEnumerable<IFeature>
    {
        int Count { get; }

        IFeaturesContainer Register(IFeature feature, Func<bool> isEnabled);
        IFeature Resolve(FeatureKey key);
        bool IsSettingEnabled(FeatureKey key);

        void Clear();
    }
}