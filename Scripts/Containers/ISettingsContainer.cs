using com.github.TheCSUser.HideItBobby.Features;
using System;
using System.Collections.Generic;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal interface ISettingsContainer : IDictionary<FeatureKey, Func<bool>>
    {
        ISettingsContainer Register(FeatureKey key, Func<bool> function);
        Func<bool> Resolve(FeatureKey key);
        bool Get(FeatureKey key);
    }
}