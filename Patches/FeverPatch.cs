using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using SelectiveEffects.Managers;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(FeverEffectManager))]
internal static class FeverPatch
{
    [HarmonyPatch(nameof(FeverEffectManager.ActivateFever))]
    [HarmonyPostfix]
    internal static void ActivateFeverPostfix(FeverEffectManager __instance)
    {
        if (GlobalDataBase.s_DbTouhou.isBadApple || !SettingsManager.Get<MainCategory>().IsEnabled)
            return;

        var feverCategory = SettingsManager.Get<FeverCategory>();

        if (feverCategory.DisableFever)
        {
            __instance.gameObject.SetActive(false);
            return;
        }

        if (feverCategory.DisableBG)
            // This option makes it work just as ballcock
            __instance.m_Background.SetActive(false);

        if (!feverCategory.DisableStars)
            return;

        foreach (var go in __instance.m_Particles)
            go.SetActive(false);
    }

    [HarmonyPatch(nameof(FeverEffectManager.CancelFeverEffect))]
    [HarmonyPrefix]
    internal static bool CancelFeverEffectPrefix(FeverEffectManager __instance)
    {
        var feverCategory = SettingsManager.Get<FeverCategory>();
        if (
            GlobalDataBase.s_DbTouhou.isBadApple
            || !SettingsManager.Get<MainCategory>().IsEnabled
            || feverCategory.DisableFever
            || !feverCategory.DisableTransition
        )
            return true;

        __instance.m_IsActivatedComeOut = true;
        __instance.gameObject.SetActive(false);
        return false;
    }
}
