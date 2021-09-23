using com.github.TheCSUser.Shared.Common;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideCongratulationPanel : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideCongratulationPanel;

        public HideCongratulationPanel(IModContext context) : base(context) { }

        protected override bool OnInitialize()
        {
            Patcher.Patch(UnlockingPanelProxy.Patch);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(UnlockingPanelProxy.Patch);
            return true;
        }

        protected override bool OnEnable()
        {
            UnlockingPanelProxy.Hide = true;
            return true;
        }
        protected override bool OnDisable()
        {
            UnlockingPanelProxy.Hide = false;
            return true;
        }
    }

    #region Harmony patch
    internal static class UnlockingPanelProxy
    {
        public static bool Hide;

        public static readonly PatchData Patch = new PatchData(
                patchId: $"{nameof(HideCongratulationPanel)}.{nameof(UnlockingPanelProxy)}.{nameof(Prefix)}",
                target: () => typeof(UnlockingPanel).GetMethod("ShowModal", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
                prefix: () => typeof(UnlockingPanelProxy).GetMethod(nameof(Prefix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
                onUnpatch: () => { Hide = false; }
            );

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix() => !Patch.IsApplied || !Hide;
    }
    #endregion
}