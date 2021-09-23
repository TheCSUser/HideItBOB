using com.github.TheCSUser.HideItBobby.Compatibility.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Compatibility
{
    internal sealed class TreeAnarchyModEnabledCheck : ModEnabledCheck
    {
        public TreeAnarchyModEnabledCheck(IModContext context) : base(
            context,
            (pluginInfo) => pluginInfo?.name == "2527486462" || pluginInfo?.name == "2584051448"
        )
        { }
    }
}