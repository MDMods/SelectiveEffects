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
        if (GlobalDataBase.s_DbTouhou.isBadApple
            || !SettingsManager.IsEnabled) return;

        if (SettingsManager.DisableFever)
        {
            __instance.gameObject.SetActive(false);
            return;
        }

        if (SettingsManager.DisableBG)
            // This option makes it work just as ballcock
            __instance.m_Background.SetActive(false);

        if (!SettingsManager.DisableStars) return;


        foreach (var go in __instance.m_Particles) go.SetActive(false);
    }


    
    [HarmonyPatch(nameof(FeverEffectManager.CancelFeverEffect))]
    [HarmonyPrefix]
    internal static bool CancelFeverEffectPrefix(FeverEffectManager __instance)
    {
        if (GlobalDataBase.s_DbTouhou.isBadApple
            || !SettingsManager.IsEnabled
            || SettingsManager.DisableFever
            || !SettingsManager.DisableTransition) return true;

        __instance.m_IsActivatedComeOut = true;
        __instance.gameObject.SetActive(false);
        return false;
    }
}