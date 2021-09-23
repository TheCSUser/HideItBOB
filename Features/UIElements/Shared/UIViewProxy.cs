using ColossalFramework.UI;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements.Shared
{
    internal static class UIViewProxy
    {
        public static event Action<UIView, Vector2, Vector2> BeforeResolutionChanged;
        public static event Action<UIView, Vector2, Vector2> AfterResolutionChanged;

        public static IEnumerable<PatchData> Patches
        {
            get
            {
                yield return OnResolutionChangedPrefixPatch;
                yield return OnResolutionChangedPostfixPatch;
            }
        }

        public static readonly PatchData OnResolutionChangedPrefixPatch = new PatchData(
            patchId: $"{nameof(UIViewProxy)}.{nameof(OnResolutionChangedPrefix)}",
            target: () => typeof(UIView).GetMethod(
                "OnResolutionChanged",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                null,
                new Type[] { typeof(Vector2), typeof(Vector2) },
                null),
            prefix: () => typeof(UIViewProxy).GetMethod(nameof(OnResolutionChangedPrefix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
            onUnpatch: () => { BeforeResolutionChanged = null; }
        );
        public static readonly PatchData OnResolutionChangedPostfixPatch = new PatchData(
            patchId: $"{nameof(UIViewProxy)}.{nameof(OnResolutionChangedPostfix)}",
            target: () => typeof(UIView).GetMethod(
                "OnResolutionChanged",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                null,
                new Type[] { typeof(Vector2), typeof(Vector2) },
                null),
            postfix: () => typeof(UIViewProxy).GetMethod(nameof(OnResolutionChangedPostfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
            onUnpatch: () => { AfterResolutionChanged = null; }
        );

        private static bool OnResolutionChangedPrefix(UIView __instance, Vector2 oldSize, Vector2 currentSize)
        {
            if (!OnResolutionChangedPrefixPatch.IsApplied) return true;

            var handler = BeforeResolutionChanged;
            if (!(handler is null)) handler(__instance, oldSize, currentSize);
            return true;
        }

        private static void OnResolutionChangedPostfix(UIView __instance, Vector2 oldSize, Vector2 currentSize)
        {
            if (!OnResolutionChangedPostfixPatch.IsApplied) return;

            var handler = AfterResolutionChanged;
            if (!(handler is null)) handler(__instance, oldSize, currentSize);
        }
    }
}