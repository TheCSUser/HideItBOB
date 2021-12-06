using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class RequiredDLCCheck : CompatibilityCheckBase
    {
        private readonly SteamHelper.DLC _requiredDLC;

        public RequiredDLCCheck(IModContext context, SteamHelper.DLC requiredDLC) : base(context)
        {
            _requiredDLC = requiredDLC;
        }

        protected sealed override bool Check() => SteamHelper.IsDLCOwned(_requiredDLC);
    }
}