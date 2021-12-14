using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.HideItBobby.Compatibility.Base;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEngine;


namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    using ILogger = TheCSUser.Shared.Logging.ILogger;

    internal sealed class ToolBaseProxy : WithContext, IManagedLifecycle
    {
        private static bool _disableNetToolCursorInfo = false;
        private static bool _disableTreeToolCursorInfo = true;
        private static bool _disableBuildingToolCursorInfo = true;
        private static bool _disablePropToolCursorInfo = false;
        private static IModContext _context;
        private static new ILogger Log => _context?.Log ?? TheCSUser.Shared.Logging.Log.None;

        public bool DisableNetToolCursorInfo { get => _disableNetToolCursorInfo; set => _disableNetToolCursorInfo = value; }
        public bool DisableTreeToolCursorInfo { get => _disableTreeToolCursorInfo; set => _disableTreeToolCursorInfo = value; }
        public bool DisableBuildingToolCursorInfo { get => _disableBuildingToolCursorInfo; set => _disableBuildingToolCursorInfo = value; }
        public bool DisablePropToolCursorInfo { get => _disablePropToolCursorInfo; set => _disablePropToolCursorInfo = value; }

        public IEnumerable<PatchData> Patches
        {
            get
            {
                yield return ShowToolInfoPatch;
            }
        }

        private static IModCheck _propLineToolModSubscribedCheck = ModCheck.NotCompatible;
        private static IModCheck _propLineToolModEnabledCheck = ModCheck.NotCompatible;

        public ToolBaseProxy(IModContext context) : base(context)
        {
            _propLineToolModSubscribedCheck = context.Resolve<PropLineToolModSubscribedCheck>();
            _propLineToolModEnabledCheck = context.Resolve<PropLineToolModEnabledCheck>();
            _context = context;
        }

        private static readonly PatchData ShowToolInfoPatch = new PatchData(
            patchId: $"{nameof(ToolBaseProxy)}.{nameof(ShowToolInfoPatch)}",
            target: () => typeof(ToolBase).GetMethod(
                "ShowToolInfo",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                null,
                new Type[] { typeof(bool), typeof(string), typeof(Vector3) },
                null),
            prefix: () => typeof(ToolBaseProxy).GetMethod(nameof(ShowToolInfoPrefix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Personal preference")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Personal preference")]
        private static bool ShowToolInfoPrefix(ToolBase __instance, bool show, string text, Vector3 worldPos)
        {
            try
            {
                if (!show) return true;
                switch (__instance?.GetType()?.Name)
                {
                    case nameof(NetTool):
                        return !_disableNetToolCursorInfo;
                    case nameof(TreeTool):
                        return !_disableTreeToolCursorInfo;
                    case nameof(BuildingTool):
                        return !_disableBuildingToolCursorInfo;
                    case nameof(PropTool):
                        return !_disablePropToolCursorInfo;
                    case nameof(BulldozeTool):
                        var m_hoverInstance = (InstanceID)((BulldozeTool)__instance).GetField("m_hoverInstance");
                        if (m_hoverInstance.Building != 0) return !_disableBuildingToolCursorInfo;
                        if (m_hoverInstance.NetSegment != 0) return !_disableNetToolCursorInfo;
                        if (m_hoverInstance.Tree != 0U) return !_disableTreeToolCursorInfo;
                        return true;
                    case "PropLineTool":
                        if (!_propLineToolModEnabledCheck.Result) return true;
                        switch (GetPropLineToolObjectMode(__instance))
                        {
                            case 1:
                                return !_disablePropToolCursorInfo;
                            case 2:
                                return !_disableTreeToolCursorInfo;
                            default:
                                return true;
                        }
                    default:
                        return true;
                }
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(ToolBaseProxy)}.{nameof(ShowToolInfoPrefix)} failed", e);
                return false;
            }
        }

        private static int GetPropLineToolObjectMode(ToolBase instance)
        {
            var value = instance
                ?.GetType()
                ?.GetStaticField<object>("m_objectMode");
            return value is null ? 0 : (int)value;
        }

        #region ManagedLifecycle
        public IInitializable GetLifecycleManager() => LifecycleManager.None;
        #endregion
    }
}
