using com.github.TheCSUser.HideItBobby.Features;
using System.Collections.Generic;

namespace com.github.TheCSUser.HideItBobby.Scripts
{
    internal interface IFeaturesContainer : IDictionary<FeatureKey, IFeature>
    {
        IFeaturesContainer Register(IFeature feature);
        IFeature Resolve(FeatureKey key);
    }
}