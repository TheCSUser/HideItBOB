using com.github.TheCSUser.HideItBobby.Features.UIElements.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Menu
{
    internal sealed class HideMainMenuVersionNumber : HideUIComponentByName
    {
        public override FeatureKey Key => FeatureKey.HideMainMenuVersionNumber;

        public HideMainMenuVersionNumber(IModContext context) : base(context, "VersionNumber") { }
    }
}