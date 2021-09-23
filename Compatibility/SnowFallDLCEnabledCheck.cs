using com.github.TheCSUser.HideItBobby.Compatibility.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Compatibility
{
    internal sealed class SnowFallDLCEnabledCheck : RequiredDLCCheck
    {
        public SnowFallDLCEnabledCheck(IModContext context) : base(context, SteamHelper.DLC.SnowFallDLC) { }
    }
}
