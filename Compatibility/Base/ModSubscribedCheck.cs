using ColossalFramework;
using ColossalFramework.Plugins;
using com.github.TheCSUser.Shared.Common;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal interface IModCheck : ICheck
    {
        PluginManager.PluginInfo PluginInfo { get; }
        IUserMod ModInstance { get; }
    }

    internal static class ModCheck
    {
        public static readonly IModCheck Compatible = new ConstantResultCheck(true);
        public static readonly IModCheck NotCompatible = new ConstantResultCheck(false);

        private sealed class ConstantResultCheck : IModCheck
        {
            private readonly bool _isCompatible;
            public bool Result => _isCompatible;

            public PluginManager.PluginInfo PluginInfo => null;
            public IUserMod ModInstance => null;

            public ConstantResultCheck(bool value)
            {
                _isCompatible = value;
            }

            public void Reset() { }
        }
    }

    internal abstract class ModSubscribedCheck : CompatibilityCheckBase, IModCheck
    {
        private Dictionary<string, PluginManager.PluginInfo> Plugins => (Dictionary<string, PluginManager.PluginInfo>)Singleton<PluginManager>.instance.GetField("m_Plugins");

        private int _pluginsCount = 0;
        private PluginManager.PluginInfo _plugin = null;

        private readonly Func<PluginManager.PluginInfo, bool> _predicate;

        public PluginManager.PluginInfo PluginInfo => _plugin;
        public IUserMod ModInstance => _plugin?.userModInstance as IUserMod;

        public ModSubscribedCheck(IModContext context, string name) : this(context, (p) => p.name == name) { }
        public ModSubscribedCheck(IModContext context, Func<string, bool> namePredicate) : this(context, (p) => namePredicate(p.name)) { }
        public ModSubscribedCheck(IModContext context, Func<PluginManager.PluginInfo, bool> predicate) : base(context)
        {
            _predicate = predicate;
        }

        protected override bool Check()
        {
            if (Plugins.Count == _pluginsCount) return !(_plugin is null) && _plugin.isEnabled;
            _pluginsCount = Plugins.Count;

            foreach (PluginManager.PluginInfo pluginInfo in Plugins.Values.Where(p => !p.isCameraScript))
            {
                if (_predicate(pluginInfo))
                {
                    _plugin = pluginInfo;
                    return !(_plugin is null);
                }
            }
            return false;
        }

        public override void Reset()
        {
            _pluginsCount = 0;
            _plugin = null;
            base.Reset();
        }
    }
}