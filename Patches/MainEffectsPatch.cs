using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Managers;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(Effect))]
internal static class MainEffectsPatch
{
    [HarmonyPatch(nameof(Effect.Init))]
    [HarmonyPostfix]
    internal static void InitPostfix(Effect __instance)
    {
        if (!Main.IsGameMain) return;

        if (SettingsManager.DisableAllEffects) return;

        EffectsDisablerManager.DisableEffectsList.ForEach(effectObject =>
            effectObject.CheckConditionAndAddUid(__instance.uid));
    }

    [HarmonyPatch(nameof(Effect.CreateInstance))]
    [HarmonyPostfix]
    internal static void CreateInstancePostfix(Effect __instance, ref GameObject __result)
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