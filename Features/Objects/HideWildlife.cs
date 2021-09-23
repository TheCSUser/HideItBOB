using ColossalFramework;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace com.github.TheCSUser.HideItBobby.Features.Objects
{
    internal sealed class HideWildlife : FeatureBase
    {
        public override FeatureKey Key => FeatureKey.HideWildlife;

        public HideWildlife(IModContext context) : base(context) { }

        protected override bool OnInitialize()
        {
            Patcher.Patch(WildlifeSpawnPointAIProxy.Patch);
            return true;
        }
        protected override bool OnTerminate()
        {
            Patcher.Unpatch(WildlifeSpawnPointAIProxy.Patch);
            return true;
        }

        protected override bool OnEnable()
        {
            if (!SimulationManager.exists) return false;
            WildlifeSpawnPointAIProxy.HideWildlife = true;
            SimulationManager.instance.AddAction(OnWildlifeRefresh(Context));
            return true;
        }
        protected override bool OnDisable()
        {
            WildlifeSpawnPointAIProxy.HideWildlife = false;
            return true;
        }

        private static IEnumerator OnWildlifeRefresh(IModContext context)
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
                            if (citizenManager.m_instances.m_buffer[i].Info.m_citizenAI != null && citizenManager.m_instances.m_buffer[i].Info.m_citizenAI is WildlifeAI)
                            {
                                citizenManager.ReleaseCitizenInstance((ushort)i);
                            }
                        }
                    }
                }
                else
                {
#if DEV
                    context.Log.Warning($"{nameof(HideWildlife)}.{nameof(OnWildlifeRefresh)} instance of {nameof(CitizenManager)} does not exist");
#endif
                }
            }
            catch (Exception e)
            {
                context.Log.Error($"{nameof(HideWildlife)}.{nameof(OnWildlifeRefresh)} failed", e);
            }
            yield return null;
        }
    }

    #region Harmony patch
    internal static class WildlifeSpawnPointAIProxy
    {
        public static bool HideWildlife;

        public static readonly PatchData Patch = new PatchData(
            patchId: $"{nameof(Objects.HideWildlife)}.{nameof(WildlifeSpawnPointAIProxy)}.{nameof(Postfix)}",
            target: () => typeof(WildlifeSpawnPointAI).GetMethod("CountAnimals", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance),
            postfix: () => typeof(WildlifeSpawnPointAIProxy).GetMethod(nameof(Postfix), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static),
            onUnpatch: () => { HideWildlife = false; }
        );

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Postfix(int __result) => !Patch.IsApplied || !HideWildlife ? __result : int.MaxValue;
    }
    #endregion
}