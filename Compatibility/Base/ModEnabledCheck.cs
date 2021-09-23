using ColossalFramework;
using ColossalFramework.Plugins;
using com.github.TheCSUser.Shared.Common;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class ModEnabledCheck : CompatibilityCheck
    {
        private Dictionary<string, PluginManager.PluginInfo> Plugins => (Dictionary<string, PluginManager.PluginInfo>)Singleton<PluginManager>.instance.GetField("m_Plugins");

        private int _pluginsCount = 0;
        private PluginManager.PluginInfo _plugin = null;

        private readonly Func<PluginManager.PluginInfo, bool> _predicate;

        public IUserMod ModInstance => _plugin?.userModInstance as IUserMod;

        public ModEnabledCheck(IModContext context, string name) : this(context, (p) => p.name == name) { }
        public ModEnabledCheck(IModContext context, Func<string, bool> namePredicate) : this(context, (p) => namePredicate(p.name)) { }
        public ModEnabledCheck(IModContext context, Func<PluginManager.PluginInfo, bool> predicate) : base(context)
        {
            _predicate = predicate;
        }

        protected sealed override bool Check()
        {
            if (Plugins.Count == _pluginsCount) return !(_plugin is null) && _plugin.isEnabled;
            _pluginsCount = Plugins.Count;

            foreach (PluginManager.PluginInfo pluginInfo in Plugins.Values.Where(p => !p.isCameraScript))
            {
                if (_predicate(pluginInfo))
                {
                    _plugin = pluginInfo;
                    return pluginInfo?.isEnabled ?? false;
                }
            }
            return false;
        }

        public sealed override void Reset()
        {
            _pluginsCount = 0;
            _plugin = null;
            base.Reset();
        }
    }
}