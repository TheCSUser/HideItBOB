using ColossalFramework;
using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.Shared.Checks;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.Effects.Shared
{
    [SuppressMessage("Style", "IDE0079:Remove unnecessary suppression", Justification = "Personal preference")]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Personal preference")]
    internal class DispatchPlacementEffectProxy : WithContext, IManagedLifecycle
    {
        private static bool _disablePlacementEffect;
        public bool DisablePlacementEffect { get => _disablePlacementEffect; set => _disablePlacementEffect = value; }

        private static bool _disableBulldozingEffect;
        public bool DisableBulldozingEffect { get => _disableBulldozingEffect; set => _disableBulldozingEffect = value; }

        public IEnumerable<PatchData> Patches
        {
            get
            {
                yield return BuildingToolDispatchPlacementEffectPatch;
                yield return DisasterToolDispatchPlacementEffectPatch;
                yield return NetToolDispatchPlacementEffectPatch;
                yield return PropToolDispatchPlacementEffectPatch;
                yield return TreeToolDispatchPlacementEffectPatch;
                if (!(PropLineToolDispatchPlacementEffectPatch is null)) yield return PropLineToolDispatchPlacementEffectPatch;
            }
        }

        #region C:S PatchData
        private static readonly PatchData BuildingToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(BuildingToolDispatchPlacementEffectPatch)}",
            target: () => typeof(BuildingTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(BuildingInfo), typeof(ushort), typeof(Vector3), typeof(float), typeof(int), typeof(int), typeof(bool), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(BuildingToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        private static readonly PatchData DisasterToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(DisasterToolDispatchPlacementEffectPatch)}",
            target: () => typeof(DisasterTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(Vector3), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(DisasterToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        private static readonly PatchData NetToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(NetToolDispatchPlacementEffectPatch)}",
            target: () => typeof(NetTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(float), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(NetToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        private static readonly PatchData PropToolDispatchPlacementEffectPatch = new PatchData(
            patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(PropToolDispatchPlacementEffectPatch)}",
            target: () => typeof(PropTool).GetMethod(
                "DispatchPlacementEffect",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(Vector3), typeof(bool) },
                null),
            prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(PropToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        private static readonly PatchData TreeToolDispatchPlacementEffectPatch = new PatchData(
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

        #region Mods PatchData

        private PatchData PropLineToolDispatchPlacementEffectPatch = null;

        #endregion

        public DispatchPlacementEffectProxy(IModContext context) : base(context) { }

        #region Patch methods
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool BuildingToolDispatchPlacementEffect(BuildingTool __instance, BuildingInfo info, ushort buildingID, Vector3 pos, float angle, int width, int length, bool bulldozing, bool collapsed)
        {
            if (bulldozing ? !_disableBulldozingEffect : !_disablePlacementEffect) return true;
            if (!Singleton<BuildingManager>.exists) return false;

            var properties = Singleton<BuildingManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, pos);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool DisasterToolDispatchPlacementEffect(DisasterTool __instance, Vector3 pos, bool bulldozing)
        {
            if (bulldozing ? !_disableBulldozingEffect : !_disablePlacementEffect) return true;
            if (!Singleton<PropManager>.exists) return false;

            var properties = Singleton<PropManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, pos);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool NetToolDispatchPlacementEffect(NetTool __instance, Vector3 startPos, Vector3 middlePos1, Vector3 middlePos2, Vector3 endPos, float halfWidth, bool bulldozing)
        {
            if (bulldozing ? !_disableBulldozingEffect : !_disablePlacementEffect) return true;
            if (!Singleton<NetManager>.exists) return false;

            var properties = Singleton<NetManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, (startPos + middlePos1 + middlePos2 + endPos) / 4);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool PropToolDispatchPlacementEffect(PropTool __instance, Vector3 pos, bool bulldozing)
        {
            if (bulldozing ? !_disableBulldozingEffect : !_disablePlacementEffect) return true;
            if (!Singleton<PropManager>.exists) return false;

            var properties = Singleton<PropManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, pos);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool TreeToolDispatchPlacementEffect(TreeTool __instance, Vector3 pos, bool bulldozing)
        {
            if (bulldozing ? !_disableBulldozingEffect : !_disablePlacementEffect) return true;
            if (!Singleton<TreeManager>.exists) return false;

            var properties = Singleton<TreeManager>.instance.m_properties;
            var effect = bulldozing ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, pos);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool PropLineToolDispatchPlacementEffect(ToolBase __instance, Vector3 position, bool isBulldozeEffect)
        {
            if (isBulldozeEffect ? !_disableBulldozingEffect : !_disablePlacementEffect) return true;
            if (!Singleton<TreeManager>.exists) return false;

            var properties = Singleton<TreeManager>.instance.m_properties;
            var effect = isBulldozeEffect ? properties.m_bulldozeEffect : properties.m_placementEffect;
            DispatchSoundEffect(effect, position);
            return false;
        }

        #region Helpers
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
        #endregion
        #endregion

        #region ManagedLifecycle
        private IInitializable _lifecycleManager;
        public IInitializable GetLifecycleManager() => _lifecycleManager ?? (_lifecycleManager = new DispatchPlacementEffectProxyLifecycleManager(this));

        private sealed class DispatchPlacementEffectProxyLifecycleManager : LifecycleManager
        {
            private readonly DispatchPlacementEffectProxy _parent;

            private readonly ModCheck _check;

            public DispatchPlacementEffectProxyLifecycleManager(DispatchPlacementEffectProxy parent) : base(parent.Context)
            {
                _parent = parent;
                _check = Context.Resolve<ModCheck>(Mods.PropLineTool);
            }

            protected override bool OnInitialize()
            {
                if (_check.IsSubscribed)
                {
                    var propLineTool = _check
                        .ModInstance.GetType()
                        .Assembly.GetTypes()
                        .FirstOrDefault(t => t.IsSubclassOf(typeof(ToolBase)) && t.Name == "PropLineTool");
                    if (!(propLineTool is null))
                    {
                        var target = propLineTool.GetMethod(
                            "DispatchPlacementEffect",
                            BindingFlags.Public | BindingFlags.Static,
                            null,
                            new Type[] { typeof(Vector3), typeof(bool) },
                            null);
                        if (!(target is null))
                        {
                            _parent.PropLineToolDispatchPlacementEffectPatch = new PatchData(
                                patchId: $"{nameof(DispatchPlacementEffectProxy)}.{nameof(PropLineToolDispatchPlacementEffectPatch)}",
                                target: () => target,
                                prefix: () => typeof(DispatchPlacementEffectProxy).GetMethod(nameof(PropLineToolDispatchPlacementEffect), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
                                );
                        }
                        else
                        {
                            _parent.PropLineToolDispatchPlacementEffectPatch = null;
                            Log.Error($"{nameof(DispatchPlacementEffectProxyLifecycleManager)}.{nameof(OnInitialize)} invalid PropLineToolDispatchPlacementEffectPatch target");
                        }
                    }
                    else
                    {
                        _parent.PropLineToolDispatchPlacementEffectPatch = null;
                        Log.Error($"{nameof(DispatchPlacementEffectProxyLifecycleManager)}.{nameof(OnInitialize)} could not find PropLineTool BaseTool implementation");
                    }
                }
                else
                {
                    _parent.PropLineToolDispatchPlacementEffectPatch = null;
                }
                return true;
            }

            protected override bool OnTerminate()
            {
                _parent.PropLineToolDispatchPlacementEffectPatch = null;
                return true;
            }
        }
        #endregion
    }
}