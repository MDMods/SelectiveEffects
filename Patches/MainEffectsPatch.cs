using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Managers;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches
{
    [HarmonyPatch(typeof(Effect), nameof(Effect.CreateInstance))]
    internal class MainEffectsPatch
    {
        public static void Postfix(Effect __instance, ref GameObject __result)
        {
            if (!SettingsManager.Enabled) return;

            
            if (SettingsManager.DisableAllEffects)
            {
                __result.SetActive(false);
                return;
            }
            

            if (SettingsManager.DisableAllEffects || !EffectsDisablerManager.AnyEffect) return;

            string fxName = __instance.uid;
            foreach (EffectsCondition effecObject in EffectsDisablerManager.effectsDisablerList)
            {
                if (!effecObject.Condition(fxName)) continue;

                __result.SetActive(false);
                return;
            }
        }
    }
}
