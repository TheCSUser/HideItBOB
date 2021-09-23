using com.github.TheCSUser.HideItBobby.Features.Menu.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features.Menu
{
    internal sealed class HideMainMenuChirper : HideMainMenuElement
    {
        public override FeatureKey Key => FeatureKey.HideMainMenuChirper;

        public HideMainMenuChirper(IModContext context) : base(context, "Chirper") { }
    }
}