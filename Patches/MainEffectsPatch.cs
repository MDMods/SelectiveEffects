using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Managers;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches
{
    [HarmonyPatch(typeof(Effect), nameof(Effect.CreateInstance))]
    internal class MainEffectsPatch
    {
        internal static GameObject EmptyObject = new("EmptyObject");

        public static bool Prefix(ref GameObject __result)
        {
            __result = EmptyObject;
            return !SettingsManager.DisableAllEffects;
        }

        public static void Postfix(Effect __instance, ref GameObject __result)
        {
            if (SettingsManager.DisableAllEffects || !EffectsDisablerManager.AnyEffect) return;

            string fxName = __instance.uid;
            foreach (EffectsCondition x in EffectsDisablerManager.effectsDisablerList)
            {
                if (!x.Condition(fxName)) continue;

                __result.SetActive(false);
                return;
            }
        }
    }
}
