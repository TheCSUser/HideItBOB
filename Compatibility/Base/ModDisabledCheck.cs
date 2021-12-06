using ColossalFramework.Plugins;
using com.github.TheCSUser.Shared.Common;
using System;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class ModDisabledCheck : ModSubscribedCheck
    {
        public ModDisabledCheck(IModContext context, string name) : base(context, name) { }
        public ModDisabledCheck(IModContext context, Func<string, bool> namePredicate) : base(context, namePredicate) { }
        public ModDisabledCheck(IModContext context, Func<PluginManager.PluginInfo, bool> predicate) : base(context, predicate) { }

        protected sealed override bool Check() => !base.Check() || !PluginInfo.isEnabled;
    }
}