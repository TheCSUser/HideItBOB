using com.github.TheCSUser.HideItBobby.Compatibility.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Compatibility
{
    internal sealed class NaturalDisastersDLCEnabledCheck : RequiredDLCCheck
    {
        public NaturalDisastersDLCEnabledCheck(IModContext context) : base(context, SteamHelper.DLC.NaturalDisastersDLC) { }
    }
}
