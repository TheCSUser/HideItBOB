using ColossalFramework.UI;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace com.github.TheCSUser.HideItBobby.Features.Menu.Shared
{
    internal static class MainMenuProxy
    {
        public static event Action<MainMenu, bool> OnVisibilityChanged;
        public static event Action<MainMenu> OnCreditsEnded;

        public static IEnumerable<PatchData> Patches
        {
            get
            {
                yield return OnVisibilityChangedPatch;
                yield return CreditsEndedPatch;
            }
        }

        public static readonly PatchData OnVisibilityChangedPatch = new PatchData(
                patchId: $"SharedPatch.{nameof(MainMenuProxy)}.{nameof(OnVisibilityChangedPostfix)}",
                target: () => typeof(MainMenu).GetMethod("OnVisibilityChanged", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
                postfix: () => typeof(MainMenuProxy).GetMethod(nameof(OnVisibilityChangedPostfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
                onUnpatch: () => { OnVisibilityChanged = null; }
            );
        public static readonly PatchData CreditsEndedPatch = new PatchData(
            patchId: $"SharedPatch.{nameof(MainMenuProxy)}.{nameof(CreditsEndedPostfix)}",
            target: () => typeof(MainMenu).GetMethod("CreditsEnded", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(MainMenuProxy).GetMethod(nameof(CreditsEndedPostfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
            onUnpatch: () => { OnCreditsEnded = null; }
        );

        [MethodImpl(MethodImplOptions.NoInlining)]
        [SuppressMessage("Style", "IDE0079:Remove unnecessary suppression", Justification = "Personal preference")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Personal preference")]
        public static void OnVisibilityChangedPostfix(MainMenu __instance, UIComponent comp, bool visible)
        {
            try
            {
                if (!OnVisibilityChangedPatch.IsApplied) return;
                var handler = OnVisibilityChanged;
                if (!(handler is null)) handler(__instance, visible);
            }
            catch { /* ignore */ }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CreditsEndedPostfix(MainMenu __instance)
        {
            try
            {
                if (!CreditsEndedPatch.IsApplied) return;
                var handler = OnCreditsEnded;
                if (!(handler is null)) handler(__instance);
            }
            catch { /* ignore */ }
        }
    }
}