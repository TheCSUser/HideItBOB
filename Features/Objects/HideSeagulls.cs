using ColossalFramework;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace com.github.TheCSUser.HideItBobby.Features.Objects
{
    internal sealed class HideSeagulls : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideSeagulls;

        public HideSeagulls(IModContext context) : base(context) { }

        protected override bool OnInitialize()
        {
            Patcher.Patch(CountAnimalsProxy.Patches);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(CountAnimalsProxy.Patches);
            return true;
        }

        protected override bool OnEnable()
        {
            if (!SimulationManager.exists) return false;
            CountAnimalsProxy.HideSeagulls = true;
            SimulationManager.instance.AddAction(OnSeagullsRefresh(Context));
            return true;
        }
        protected override bool OnDisable()
        {
            CountAnimalsProxy.HideSeagulls = false;
            return true;
        }

        private static IEnumerator OnSeagullsRefresh(IModContext context)
        {
            try
            {
                if (Singleton<CitizenManager>.exists)
                {
                    var citizenManager = Singleton<CitizenManager>.instance;
                    for (int i = 1; i < citizenManager.m_instances.m_buffer.Length; i++)
                    {
                        if ((citizenManager.m_instances.m_buffer[i].m_flags & CitizenInstance.Flags.Created) != CitizenInstance.Flags.None)
                        {
                            if (citizenManager.m_instances.m_buffer[i].Info.m_citizenAI != null && citizenManager.m_instances.m_buffer[i].Info.m_citizenAI is BirdAI)
                            {
                                citizenManager.ReleaseCitizenInstance((ushort)i);
                            }
                        }
                    }
                }
                else
                {
#if DEV
                    context.Log.Warning($"{nameof(HideSeagulls)}.{nameof(OnSeagullsRefresh)} instance of {nameof(CitizenManager)} does not exist");
#endif
                }
            }
            catch (Exception e)
            {
                context.Log.Error($"{nameof(HideSeagulls)}.{nameof(OnSeagullsRefresh)} failed", e);
            }

            yield return null;
        }
    }

    #region Harmony patches
    internal static class CountAnimalsProxy
    {
        public static bool HideSeagulls;

        public static IEnumerable<PatchData> Patches
        {
            get
            {
                yield return CargoHarborAIPatch;
                yield return HarborAIPatch;
                yield return IndustryBuildingAIPatch;
                yield return LandfillSiteAIPatch;
                yield return ParkAIPatch;
                yield return ParkBuildingAIPatch;
                yield return WarehouseAIPatch;
            }
        }

        public static readonly PatchData CargoHarborAIPatch = new PatchData(
            patchId: $"{nameof(Objects.HideSeagulls)}.{nameof(CountAnimalsProxy)}.{nameof(CargoHarborAI_CountAnimals_Postfix)}",
            target: () => typeof(CargoHarborAI).GetMethod("CountAnimals", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(CountAnimalsProxy).GetMethod(nameof(CargoHarborAI_CountAnimals_Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );
        public static readonly PatchData HarborAIPatch = new PatchData(
            patchId: $"{nameof(Objects.HideSeagulls)}.{nameof(CountAnimalsProxy)}.{nameof(HarborAI_CountAnimals_Postfix)}",
            target: () => typeof(HarborAI).GetMethod("CountAnimals", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(CountAnimalsProxy).GetMethod(nameof(HarborAI_CountAnimals_Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );
        public static readonly PatchData IndustryBuildingAIPatch = new PatchData(
            patchId: $"{nameof(Objects.HideSeagulls)}.{nameof(CountAnimalsProxy)}.{nameof(IndustryBuildingAI_CountAnimals_Postfix)}",
            target: () => typeof(IndustryBuildingAI).GetMethod("CountAnimals", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(CountAnimalsProxy).GetMethod(nameof(IndustryBuildingAI_CountAnimals_Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );
        public static readonly PatchData LandfillSiteAIPatch = new PatchData(
            patchId: $"{nameof(Objects.HideSeagulls)}.{nameof(CountAnimalsProxy)}.{nameof(LandfillSiteAI_CountAnimals_Postfix)}",
            target: () => typeof(LandfillSiteAI).GetMethod("CountAnimals", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(CountAnimalsProxy).GetMethod(nameof(LandfillSiteAI_CountAnimals_Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );
        public static readonly PatchData ParkAIPatch = new PatchData(
            patchId: $"{nameof(Objects.HideSeagulls)}.{nameof(CountAnimalsProxy)}.{nameof(ParkAI_CountAnimals_Postfix)}",
            target: () => typeof(ParkAI).GetMethod("CountAnimals", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(CountAnimalsProxy).GetMethod(nameof(ParkAI_CountAnimals_Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );
        public static readonly PatchData ParkBuildingAIPatch = new PatchData(
            patchId: $"{nameof(Objects.HideSeagulls)}.{nameof(CountAnimalsProxy)}.{nameof(ParkBuildingAI_CountAnimals_Postfix)}",
            target: () => typeof(ParkBuildingAI).GetMethod("CountAnimals", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(CountAnimalsProxy).GetMethod(nameof(ParkBuildingAI_CountAnimals_Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );
        public static readonly PatchData WarehouseAIPatch = new PatchData(
            patchId: $"{nameof(Objects.HideSeagulls)}.{nameof(CountAnimalsProxy)}.{nameof(WarehouseAI_CountAnimals_Postfix)}",
            target: () => typeof(WarehouseAI).GetMethod("CountAnimals", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(CountAnimalsProxy).GetMethod(nameof(WarehouseAI_CountAnimals_Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        );

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int CargoHarborAI_CountAnimals_Postfix(int __result) => !CargoHarborAIPatch.IsApplied || !HideSeagulls ? __result : int.MaxValue;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int HarborAI_CountAnimals_Postfix(int __result) => !HarborAIPatch.IsApplied || !HideSeagulls ? __result : int.MaxValue;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int IndustryBuildingAI_CountAnimals_Postfix(int __result) => !IndustryBuildingAIPatch.IsApplied || !HideSeagulls ? __result : int.MaxValue;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int LandfillSiteAI_CountAnimals_Postfix(int __result) => !LandfillSiteAIPatch.IsApplied || !HideSeagulls ? __result : int.MaxValue;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ParkAI_CountAnimals_Postfix(int __result) => !ParkAIPatch.IsApplied || !HideSeagulls ? __result : int.MaxValue;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ParkBuildingAI_CountAnimals_Postfix(int __result) => !ParkBuildingAIPatch.IsApplied || !HideSeagulls ? __result : int.MaxValue;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int WarehouseAI_CountAnimals_Postfix(int __result) => !WarehouseAIPatch.IsApplied || !HideSeagulls ? __result : int.MaxValue;
    }
    #endregion
}