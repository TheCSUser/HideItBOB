using ColossalFramework;
using ColossalFramework.Plugins;
using com.github.TheCSUser.Shared.Common;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class ModEnabledCheck : ModSubscribedCheck
    {
        public ModEnabledCheck(IModContext context, string name) : base(context, name) { }
        public ModEnabledCheck(IModContext context, Func<string, bool> namePredicate) : base(context, namePredicate) { }
        public ModEnabledCheck(IModContext context, Func<PluginManager.PluginInfo, bool> predicate) : base(context, predicate) { }

        protected sealed override bool Check() => base.Check() && PluginInfo.isEnabled;
    }
}