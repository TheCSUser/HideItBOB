using ColossalFramework;
using ColossalFramework.Math;
using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.Effects.Shared
{
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Personal preference")]
    internal static class DispatchPlacementEffectProxy
    {
        public static bool DisablePlacementEffect;
        public static bool DisableBulldozingEffect;

        public static IEnumerable<PatchData> Patches
        {
            get
            {
                yield return BuildingToolDispatchPlacementEffectPatch;
                yield return DisasterToolDispatchPlacementEffectPatch;
                yield return NetToolDispatchPlacementEffectPatch;
                yield return PropToolDispatchPlacementEffectPatch;
                yield return TreeToolDispatchPlacementEffectPatch;
            }
        }

        #region PatchData
        public static readonly PatchData BuildingToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(BuildingToolDispatchPlacementEffectPatch)}",
            target: () => typeof(BuildingTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(BuildingInfo), typeof(ushort), typeof(Vector3), typeof(float), typeof(int), typeof(int), typeof(bool), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(BuildingToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        public static readonly PatchData DisasterToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(DisasterToolDispatchPlacementEffectPatch)}",
            target: () => typeof(DisasterTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(Vector3), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(DisasterToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        public static readonly PatchData NetToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(NetToolDispatchPlacementEffectPatch)}",
            target: () => typeof(NetTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(float), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(NetToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        public static readonly PatchData PropToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(PropToolDispatchPlacementEffectPatch)}",
            target: () => typeof(PropTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(Vector3), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(PropToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        public static readonly PatchData TreeToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(TreeToolDispatchPlacementEffectPatch)}",
            target: () => typeof(TreeTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(Vector3), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(TreeToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );
        #endregion

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool BuildingToolDispatchPlacementEffect(BuildingTool __instance, BuildingInfo info, ushort buildingID, Vector3 pos, float angle, int width, int length, bool bulldozing, bool collapsed)
        {
            if (bulldozing ? !DisableBulldozingEffect : !DisablePlacementEffect) return true;
            if (!Singleton<BuildingManager>.exists) return false;

            var properties = Singleton<BuildingManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, pos);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool DisasterToolDispatchPlacementEffect(BuildingTool __instance, Vector3 pos, bool bulldozing)
        {
            if (bulldozing ? !DisableBulldozingEffect : !DisablePlacementEffect) return true;
            if (!Singleton<PropManager>.exists) return false;

            var properties = Singleton<PropManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, pos);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool NetToolDispatchPlacementEffect(BuildingTool __instance, Vector3 startPos, Vector3 middlePos1, Vector3 middlePos2, Vector3 endPos, float halfWidth, bool bulldozing)
        {
            if (bulldozing ? !DisableBulldozingEffect : !DisablePlacementEffect) return true;
            if (!Singleton<NetManager>.exists) return false;

            var properties = Singleton<NetManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, (startPos + middlePos1 + middlePos2 + endPos) / 4);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool PropToolDispatchPlacementEffect(BuildingTool __instance, Vector3 pos, bool bulldozing)
        {
            if (bulldozing ? !DisableBulldozingEffect : !DisablePlacementEffect) return true;
            if (!Singleton<PropManager>.exists) return false;

            var properties = Singleton<PropManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, pos);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool TreeToolDispatchPlacementEffect(BuildingTool __instance, Vector3 pos, bool bulldozing)
        {
            if (bulldozing ? !DisableBulldozingEffect : !DisablePlacementEffect) return true;
            if (!Singleton<TreeManager>.exists) return false;

            var properties = Singleton<TreeManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, pos);
            return false;
        }

        private static void DispatchSoundEffect(EffectInfo effect, Vector3 pos)
        {
            if (effect is null) return;

            var soundEffect = GetSoundEffect(effect);
            var spawnArea = new EffectInfo.SpawnArea(pos, Vector3.up, 1f);
            Singleton<EffectManager>.instance.DispatchEffect(soundEffect, spawnArea, Vector3.zero, 0.0f, 1f, Singleton<AudioManager>.instance.DefaultGroup, 0U, true);
        }

        private static EffectInfo GetSoundEffect(EffectInfo effect)
        {
            if (effect is MultiEffect multiEffect)
            {
                return multiEffect
                    .m_effects
                    .Where(x => x.m_probability > 0.0f)
                    .Select(x => x.m_effect)
                    .FirstOrDefault(x => x is SoundEffect);
            }
            return null;
        }
    }
}