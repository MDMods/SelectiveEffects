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
    internal static void ModifyPrefabs(Effect __instance)
    {
        if (!Main.IsGameMain) return;

        if (SettingsManager.DisableAllEffects) return;

        EffectsDisablerManager.DisableEffectsList.ForEach(effectObject =>
            effectObject.CheckConditionAndAddUid(__instance.uid));
    }


    [HarmonyPostfix]
    [HarmonyPatch(nameof(Effect.CreateInstance))]
    internal static void DisableEffects(Effect __instance, ref GameObject __result)
    {
        if (!SettingsManager.IsEnabled) return;

        if (SettingsManager.DisableAllEffects)
        {
            __result.SetActive(false);
            return;
        }

        if (!EffectsDisablerManager.DisabledEffectsUids.TryGetValue(__instance.uid, out var function)) return;
        function(__result);
    }
}