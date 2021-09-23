using com.github.TheCSUser.HideItBobby.Compatibility.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Compatibility
{
    internal sealed class UIResolutionModEnabledCheck : ModEnabledCheck
    {
        public UIResolutionModEnabledCheck(IModContext context) : base(
            context,
            (pluginInfo) => pluginInfo?.name == "2487213155"
        )
        { }
    }
}