using ColossalFramework;
using ColossalFramework.Plugins;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Imports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class ModDisabledCheck : CompatibilityCheck
    {
        private Dictionary<string, PluginManager.PluginInfo> Plugins => (Dictionary<string, PluginManager.PluginInfo>)Singleton<PluginManager>.instance.GetField("m_Plugins");

        private int _pluginsCount = 0;
        private PluginManager.PluginInfo _plugin = null;

        private readonly Func<PluginManager.PluginInfo, bool> _predicate;

        public ModDisabledCheck(IModContext context, string name) : this(context, (p) => p?.name == name) { }
        public ModDisabledCheck(IModContext context, Func<string, bool> namePredicate) : this(context, (p) => namePredicate(p?.name)) { }
        public ModDisabledCheck(IModContext context, Func<PluginManager.PluginInfo, bool> predicate) : base(context)
        {
            _predicate = predicate;
        }

        protected sealed override bool Check()
        {
            if (Plugins.Count == _pluginsCount) return _plugin is null || !_plugin.isEnabled;
            _pluginsCount = Plugins.Count;

            foreach (PluginManager.PluginInfo pluginInfo in Plugins.Values.Where(p => !p.isCameraScript))
            {
                if (_predicate(pluginInfo))
                {
                    _plugin = pluginInfo;
                    return !(pluginInfo?.isEnabled ?? false);
                }
            }
            return true;
        }

        public sealed override void Reset()
        {
            _pluginsCount = 0;
            _plugin = null;
            base.Reset();
        }
    }
}