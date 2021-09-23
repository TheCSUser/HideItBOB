using com.github.TheCSUser.HideItBobby.Compatibility.Base;
using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Compatibility
{
    internal sealed class BOBModDisabledCheck : ModDisabledCheck
    {
        public BOBModDisabledCheck(IModContext context) : base(
            context,
            (pluginInfo) => pluginInfo?.name == "2197863850"
        )
        { }
    }
}