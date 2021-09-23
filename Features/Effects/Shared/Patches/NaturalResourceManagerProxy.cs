using ColossalFramework;
using com.github.TheCSUser.HideItBobby.Properties;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.Logging;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.Effects.Shared.Patches
{
    internal static class NaturalResourceManagerProxy
    {
        public static bool HidePollutedAreaEffect;
        public static bool HideBurnedAreaEffect;
        public static bool HideDestroyedAreaEffect;
        public static bool HideOreAreaEffect;
        public static bool HideOilAreaEffect;
        public static bool HideSandAreaEffect;
        public static bool HideFertilityAreaEffect;
        public static bool HideForestAreaEffect;
        public static bool HideShoreAreaEffect;

        public static readonly PatchData UpdateTextureBPatch = new PatchData(
            patchId: $"SharedPatch.{nameof(NaturalResourceManagerProxy)}.{nameof(UpdateTextureB)}",
            target: () => typeof(NaturalResourceManager).GetMethod("UpdateTextureB", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            prefix: () => typeof(NaturalResourceManagerProxy).GetMethod(nameof(UpdateTextureB), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
            onUnpatch: () =>
            {
                HidePollutedAreaEffect = false;
                HideBurnedAreaEffect = false;
                HideDestroyedAreaEffect = false;
            }
        );
        public static readonly PatchData UpdateTexturePatch = new PatchData(
           patchId: $"SharedPatch.{nameof(NaturalResourceManagerProxy)}.{nameof(UpdateTexture)}",
           target: () => typeof(NaturalResourceManager).GetMethod("UpdateTexture", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
           prefix: () => typeof(NaturalResourceManagerProxy).GetMethod(nameof(UpdateTexture), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
           onUnpatch: () =>
           {
               HideOreAreaEffect = false;
               HideOilAreaEffect = false;
               HideSandAreaEffect = false;
               HideFertilityAreaEffect = false;
               HideForestAreaEffect = false;
               HideShoreAreaEffect = false;
           }
        );

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool UpdateTextureB(NaturalResourceManager __instance)
        {
            if (!UpdateTextureBPatch.IsApplied) return true;
            try
            {
                int[] m_modifiedBX1 = (int[])__instance.GetField("m_modifiedBX1");
                int[] m_modifiedBX2 = (int[])__instance.GetField("m_modifiedBX2");

                for (int i = 0; i < 512; i++)
                {
                    if (m_modifiedBX2[i] >= m_modifiedBX1[i])
                    {
                        while (!Monitor.TryEnter(__instance.m_naturalResources, SimulationManager.SYNCHRONIZE_TIMEOUT))
                        {
                        }
                        int num1;
                        int num2;
                        try
                        {
                            num1 = m_modifiedBX1[i];
                            num2 = m_modifiedBX2[i];
                            m_modifiedBX1[i] = 10000;
                            m_modifiedBX2[i] = -10000;
                        }
                        finally
                        {
                            Monitor.Exit(__instance.m_naturalResources);
                        }
                        for (int j = num1; j <= num2; j++)
                        {
                            Color color = default;
                            if (i == 0 || j == 0 || i == 511 || j == 511)
                            {
                                color = new Color(0f, 0f, 0f, 1f);
                                InfoViewUpdater.DestructionTexture.SetPixel(j, i, color);
                            }
                            else
                            {
                                int pollution = 0;
                                int burned = 0;
                                int destroyed = 0;

                                AddResourceB(j - 1, i - 1, 5, ref pollution, ref burned, ref destroyed);
                                AddResourceB(j, i - 1, 7, ref pollution, ref burned, ref destroyed);
                                AddResourceB(j + 1, i - 1, 5, ref pollution, ref burned, ref destroyed);
                                AddResourceB(j - 1, i, 7, ref pollution, ref burned, ref destroyed);
                                AddResourceB(j, i, 14, ref pollution, ref burned, ref destroyed);
                                AddResourceB(j + 1, i, 7, ref pollution, ref burned, ref destroyed);
                                AddResourceB(j - 1, i + 1, 5, ref pollution, ref burned, ref destroyed);
                                AddResourceB(j, i + 1, 7, ref pollution, ref burned, ref destroyed);
                                AddResourceB(j + 1, i + 1, 5, ref pollution, ref burned, ref destroyed);

                                color = CalculateColorComponentsB(pollution, burned, destroyed);
                                InfoViewUpdater.DestructionTexture.SetPixel(j, i, color);

                                pollution = HidePollutedAreaEffect ? 0 : pollution;
                                burned = HideBurnedAreaEffect ? 0 : burned;
                                destroyed = HideDestroyedAreaEffect ? 0 : destroyed;

                                color = CalculateColorComponentsB(pollution, burned, destroyed);
                            }
                            __instance.m_destructionTexture.SetPixel(j, i, color);
                        }
                    }
                }
                __instance.m_destructionTexture.Apply();

                InfoViewUpdater.DestructionTexture.Apply();

                return false;
            }
            catch (Exception e)
            {
                Log.Shared.Error($"[{ModProperties.LongName}] {nameof(NaturalResourceManagerProxy)}.{nameof(UpdateTextureB)} failed", e);
                return true;
            }
        }

        #region UpdateTextureB helpers
        private static Color CalculateColorComponentsB(int pollution, int burned, int destroyed)
        {
            Color color;
            color.r = pollution * 6.325111E-05f;
            color.g = burned * 6.325111E-05f;
            color.b = destroyed * 6.325111E-05f;
            color.a = 1f;
            return color;
        }

        private static void AddResourceB(int x, int z, int multiplier, ref int pollution, ref int burned, ref int destroyed)
        {
            try
            {
                if (!Singleton<NaturalResourceManager>.exists)
                {
#if DEV
                    Log.Shared.Warning($"[{ModProperties.LongName}] {nameof(NaturalResourceManagerProxy)}.{nameof(AddResourceB)} instance of {nameof(NaturalResourceManager)} does not exist");
#endif
                    return;
                }

                x = Mathf.Clamp(x, 0, 511);
                z = Mathf.Clamp(z, 0, 511);
                var resourceCell = Singleton<NaturalResourceManager>.instance.m_naturalResources[z * 512 + x];
                pollution += resourceCell.m_pollution * multiplier;
                burned += resourceCell.m_burned * multiplier;
                destroyed += resourceCell.m_destroyed * multiplier;
            }
            catch (Exception e)
            {
                Log.Shared.Error($"[{ModProperties.LongName}] {nameof(NaturalResourceManagerProxy)}.{nameof(AddResourceB)} failed", e);
            }
        }
        #endregion

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool UpdateTexture(NaturalResourceManager __instance)
        {
            if (!UpdateTexturePatch.IsApplied) return true;
            try
            {
                int[] m_modifiedX1 = (int[])__instance.GetField("m_modifiedX1");
                int[] m_modifiedX2 = (int[])__instance.GetField("m_modifiedX2");

                for (int i = 0; i < 512; i++)
                {
                    if (m_modifiedX2[i] >= m_modifiedX1[i])
                    {
                        while (!Monitor.TryEnter(__instance.m_naturalResources, SimulationManager.SYNCHRONIZE_TIMEOUT))
                        {
                        }
                        int num1;
                        int num2;
                        try
                        {
                            num1 = m_modifiedX1[i];
                            num2 = m_modifiedX2[i];
                            m_modifiedX1[i] = 10000;
                            m_modifiedX2[i] = -10000;
                        }
                        finally
                        {
                            Monitor.Exit(__instance.m_naturalResources);
                        }
                        for (int j = num1; j <= num2; j++)
                        {
                            Color color = default;
                            if (i == 0 || j == 0 || i == 511 || j == 511)
                            {
                                color = new Color(0.5f, 0.5f, 0.5f, 0f);
                                InfoViewUpdater.ResourceTexture.SetPixel(j, i, color);
                            }
                            else
                            {
                                int ore = 0;
                                int oil = 0;
                                int sand = 0;
                                int fertility = 0;
                                int forest = 0;
                                int shore = 0;

                                AddResource(j - 1, i - 1, 5, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j, i - 1, 7, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j + 1, i - 1, 5, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j - 1, i, 7, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j, i, 14, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j + 1, i, 7, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j - 1, i + 1, 5, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j, i + 1, 7, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j + 1, i + 1, 5, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);

                                color = CalculateColorComponents(ore, oil, sand, fertility, forest, shore);
                                InfoViewUpdater.ResourceTexture.SetPixel(j, i, color);

                                ore = HideOreAreaEffect ? 0 : ore;
                                oil = HideOilAreaEffect ? 0 : oil;
                                sand = HideSandAreaEffect ? 0 : sand;
                                fertility = HideFertilityAreaEffect ? 0 : fertility;
                                forest = HideForestAreaEffect ? 0 : forest;
                                shore = HideShoreAreaEffect ? 0 : shore;

                                color = CalculateColorComponents(ore, oil, sand, fertility, forest, shore);
                            }
                            __instance.m_resourceTexture.SetPixel(j, i, color);
                        }
                    }
                }
                __instance.m_resourceTexture.Apply();

                InfoViewUpdater.ResourceTexture.Apply();

                return false;
            }
            catch (Exception e)
            {
                Log.Shared.Error($"[{ModProperties.LongName}] {nameof(NaturalResourceManagerProxy)}.{nameof(UpdateTexture)} failed", e);
                return true;
            }
        }

        #region Helpers
        private static Color CalculateColorComponents(int ore, int oil, int sand, int fertility, int forest, int shore)
        {
            Color color;

            color.r = (ore - oil + 15810) * 3.16255537E-05f;
            color.g = (sand - fertility + 15810) * 3.16255537E-05f;
            int num3 = shore * 4 - forest;
            if (num3 > 0)
            {
                color.b = (15810 + num3 / 4) * 3.16255537E-05f;
            }
            else
            {
                color.b = (15810 + num3) * 3.16255537E-05f;
            }
            color.a = 1f;

            return color;
        }

        private static void AddResource(int x, int z, int multiplier, ref int ore, ref int oil, ref int sand, ref int fertility, ref int forest, ref int shore)
        {
            try
            {
                if (!Singleton<NaturalResourceManager>.exists)
                {
#if DEV
                    Log.Shared.Warning($"[{ModProperties.LongName}] {nameof(NaturalResourceManagerProxy)}.{nameof(AddResource)} instance of {nameof(NaturalResourceManager)} does not exist");
#endif
                    return;
                }

                x = Mathf.Clamp(x, 0, 511);
                z = Mathf.Clamp(z, 0, 511);
                var resourceCell = Singleton<NaturalResourceManager>.instance.m_naturalResources[z * 512 + x];
                ore += resourceCell.m_ore * multiplier;
                oil += resourceCell.m_oil * multiplier;
                sand += resourceCell.m_sand * multiplier;
                fertility += resourceCell.m_fertility * multiplier;
                forest += resourceCell.m_forest * multiplier;
                shore += resourceCell.m_shore * multiplier;

            }
            catch (Exception e)
            {
                Log.Shared.Error($"[{ModProperties.LongName}] {nameof(NaturalResourceManagerProxy)}.{nameof(AddResource)} failed", e);
            }
        }
        #endregion
    }
}