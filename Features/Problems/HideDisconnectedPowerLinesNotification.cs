using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace com.github.TheCSUser.HideItBobby.Features.Problems
{
    internal sealed class HideDisconnectedPowerLinesNotification : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideDisconnectedPowerLinesNotification;

        public HideDisconnectedPowerLinesNotification(IModContext context) : base(context) { }

        protected override bool OnInitialize()
        {
            Patcher.Patch(PowerLineAIProxy.Patches);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(PowerLineAIProxy.Patches);
            return true;
        }

        protected override bool OnEnable()
        {
            PowerLineAIProxy.HideNotConnectedNotification = true;
            return true;
        }
        protected override bool OnDisable()
        {
            PowerLineAIProxy.HideNotConnectedNotification = false;
            return true;
        }
    }

    #region Harmony patch
    internal static class PowerLineAIProxy
    {
        public static bool HideNotConnectedNotification;

        public static IEnumerable<PatchData> Patches
        {
            get
            {
                yield return UpdateNodePatch;
                yield return SimulationStepPatch;
            }
        }

        public static readonly PatchData UpdateNodePatch = new PatchData(
            patchId: $"{nameof(HideDisconnectedPowerLinesNotification)}.{nameof(PowerLineAIProxy)}.{nameof(UpdateNodePostfix)}",
            target: () => typeof(PowerLineAI).GetMethod(
                "UpdateNode",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                null,
                new Type[] { typeof(ushort), typeof(NetNode).MakeByRefType() },
                null
            ),
            postfix: () => typeof(PowerLineAIProxy).GetMethod(nameof(UpdateNodePostfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
            onUnpatch: () => { HideNotConnectedNotification = false; }
        );
        public static readonly PatchData SimulationStepPatch = new PatchData(
            patchId: $"{nameof(HideDisconnectedPowerLinesNotification)}.{nameof(PowerLineAIProxy)}.{nameof(SimulationStepPostfix)}",
            target: () => typeof(PowerLineAI).GetMethod(
                "SimulationStep",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                null,
                new Type[] { typeof(ushort), typeof(NetNode).MakeByRefType() },
                null
            ),
            postfix: () => typeof(PowerLineAIProxy).GetMethod(nameof(SimulationStepPostfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
            onUnpatch: () => { HideNotConnectedNotification = false; }
        );


        [MethodImpl(MethodImplOptions.NoInlining)]
        [SuppressMessage("Style", "IDE0079:Remove unnecessary suppression", Justification = "Personal preference")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Personal preference")]
        public static void UpdateNodePostfix(PowerLineAI __instance, ushort nodeID, ref NetNode data)
        {
            if (!UpdateNodePatch.IsApplied || !HideNotConnectedNotification) return;
            data.m_problems = Notification.RemoveProblems(data.m_problems, Notification.Problem.ElectricityNotConnected);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [SuppressMessage("Style", "IDE0079:Remove unnecessary suppression", Justification = "Personal preference")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Personal preference")]
        public static void SimulationStepPostfix(PowerLineAI __instance, ushort nodeID, ref NetNode data)
        {
            if (!SimulationStepPatch.IsApplied || !HideNotConnectedNotification) return;
            data.m_problems = Notification.RemoveProblems(data.m_problems, Notification.Problem.ElectricityNotConnected);
        }
    }
    #endregion
}
