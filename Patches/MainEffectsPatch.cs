using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Managers;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(Effect))]
internal static class MainEffectsPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Effect.Init))]
    public static void ModifyPrefabs(Effect __instance)
    {
        if (!Main.IsGameMain) return;

        if (SettingsManager.DisableAllEffects) return;

        EffectsDisablerManager.DisableEffectsList.ForEach(effectObject =>
            effectObject.CheckConditionAndAddUid(__instance.uid));
    }


    [HarmonyPostfix]
    [HarmonyPatch(nameof(Effect.CreateInstance))]
    public static void DisableEffects(Effect __instance, ref GameObject __result)
    {
        if (!SettingsManager.IsEnabled) return;

        if (!SettingsManager.DisableAllEffects
            && !EffectsDisablerManager.DisabledEffectsUids.Contains(__instance.uid)
           ) return;
        __result.SetActive(false);
    }
}