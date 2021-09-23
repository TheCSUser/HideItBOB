using com.github.TheCSUser.HideItBobby.Features.Menu.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Menu
{
    internal sealed class HideMainMenuLogo : HideMainMenuElement
    {
        public override FeatureKey Key => FeatureKey.HideMainMenuLogo;

        public HideMainMenuLogo(IModContext context) : base(context, "Logo") { }
    }
}