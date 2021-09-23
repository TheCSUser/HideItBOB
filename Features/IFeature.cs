using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features
{
    internal interface IFeature : IInitializable<FeatureFlags>, IForceToggleable<FeatureFlags>, IErrorInfo, IAvailabilityInfo, IDisposableEx
    {
        FeatureKey Key { get; }
    }

    internal interface IUpdatableFeature : IFeature, IUpdatable<FeatureFlags> { }
}