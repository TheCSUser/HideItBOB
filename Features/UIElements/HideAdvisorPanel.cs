using com.github.TheCSUser.Shared.Common;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements
{
    internal sealed class HideAdvisorPanel : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideAdvisorPanel;

        public HideAdvisorPanel(IModContext context) : base(context) { }

        protected override bool OnInitialize()
        {
            Patcher.Patch(TutorialAdvisorPanelProxy.Patch);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(TutorialAdvisorPanelProxy.Patch);
            return true;
        }

        protected override bool OnEnable()
        {
            TutorialAdvisorPanelProxy.Hide = true;
            return true;
        }
        protected override bool OnDisable()
        {
            TutorialAdvisorPanelProxy.Hide = false;
            return true;
        }
    }

    #region Harmony patch
    internal static class TutorialAdvisorPanelProxy
    {
        public static bool Hide;

        public static readonly PatchData Patch = new PatchData(
                patchId: $"{nameof(HideAdvisorPanel)}.{nameof(TutorialAdvisorPanelProxy)}.{nameof(Prefix)}",
                target: () => typeof(TutorialAdvisorPanel).GetMethod(
                    "Show",
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                    null,
                    new Type[] { typeof(string), typeof(string), typeof(string), typeof(float), typeof(bool), typeof(bool) },
                    null),
                prefix: () => typeof(TutorialAdvisorPanelProxy).GetMethod(nameof(Prefix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
                onUnpatch: () => { Hide = false; }
            );

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix() => !Patch.IsApplied || !Hide;
    }
    #endregion
}