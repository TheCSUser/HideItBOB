using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.Shared.Checks;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace com.github.TheCSUser.HideItBobby.Features.Problems
{
    internal sealed class HideTerraformNetworkFloodNotification : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideTerraformNetworkFloodNotification;

        private readonly AssetCheck _check;
        public override bool IsAvailable => _check.IsEnabled;

        public HideTerraformNetworkFloodNotification(IModContext context) : base(context)
        {
            _check = context.Resolve<AssetCheck>(Assets.TerraformNetwork);
        }

        protected override bool OnInitialize()
        {
            Patcher.Patch(TerraformNetworkRoadBaseAIProxy.Patch);
            return true;
        }
        protected override bool OnTerminate()
        {
            _check.Reset();
            Patcher.Unpatch(TerraformNetworkRoadBaseAIProxy.Patch);
            return true;
        }

        protected override bool OnEnable()
        {
            TerraformNetworkRoadBaseAIProxy.HideFloodNotification = true;
            return true;
        }
        protected override bool OnDisable()
        {
            TerraformNetworkRoadBaseAIProxy.HideFloodNotification = false;
            return true;
        }
    }

    #region Harmony patch
    internal static class TerraformNetworkRoadBaseAIProxy
    {
        public static bool HideFloodNotification;

        public static readonly PatchData Patch = new PatchData(
            patchId: $"{nameof(HideTerraformNetworkFloodNotification)}.{nameof(TerraformNetworkRoadBaseAIProxy)}.{nameof(Postfix)}",
            target: () => typeof(RoadBaseAI).GetMethod(
                "SimulationStep",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                null,
                new Type[] { typeof(ushort), typeof(NetSegment).MakeByRefType() },
                null
            ),
            postfix: () => typeof(TerraformNetworkRoadBaseAIProxy).GetMethod(nameof(Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
            onUnpatch: () => { HideFloodNotification = false; }
        );

        [MethodImpl(MethodImplOptions.NoInlining)]
        [SuppressMessage("Style", "IDE0079:Remove unnecessary suppression", Justification = "Personal preference")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Personal preference")]
        public static void Postfix(RoadBaseAI __instance, ushort segmentID, ref NetSegment data)
        {
            if (!Patch.IsApplied || !HideFloodNotification) return;
            var name = __instance?.m_info?.gameObject?.name ?? "";
            if (!name.StartsWith("1480409620.")) return;
            data.m_flags &= ~NetSegment.Flags.Flooded;
            data.m_problems = Notification.RemoveProblems(data.m_problems, Notification.Problem.Flood | Notification.Problem.MajorProblem);
        }
    }
    #endregion
}