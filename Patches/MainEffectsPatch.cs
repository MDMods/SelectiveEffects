using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Managers;
using MuseDashMirror;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(Effect))]
internal static class MainEffectsPatch
{
    [HarmonyPatch(nameof(Effect.CreateInstance))]
    [HarmonyPostfix]
    internal static void CreateInstancePostfix(Effect __instance, ref GameObject __result)
    {
        var mainCategory = SettingsManager.Get<Managers.MainCategory>();
        if (!mainCategory.IsEnabled)
            return;

        if (mainCategory.DisableAllEffects)
        {
            __result.SetActive(false);
            return;
        }

        if (
            !EffectsDisablerManager.DisabledEffectsUids.TryGetValue(
                __instance.uid,
                out var objectAction
            )
        )
            return;
        objectAction(__result);
    }

    [HarmonyPatch(nameof(Effect.Init))]
    [HarmonyPostfix]
    internal static void InitPostfix(Effect __instance)
    {
        if (!SceneInfo.IsGameScene)
            return;

        if (SettingsManager.Get<Managers.MainCategory>().DisableAllEffects)
            return;

        EffectsDisablerManager.DisableEffectsList.ForEach(effectObject =>
            effectObject.CheckConditionAndAddUid(__instance.uid)
        );
    }
}
