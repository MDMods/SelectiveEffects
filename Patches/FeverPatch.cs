using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches
{
    [HarmonyPatch(typeof(FeverEffectManager))]
    internal static class FeverPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(FeverEffectManager.ActivateFever))]
        public static void ActivateFeverPostfix(FeverEffectManager __instance)
        {
            if (GlobalDataBase.s_DbTouhou.isBadApple
                || !SettingsManager.IsEnabled) return;

            if (SettingsManager.DisableFever)
            {
                __instance.gameObject.SetActive(false);
                return;
            }

            if (SettingsManager.DisableBG)
            {
                // This option makes it work just as ballcock
                __instance.m_Background.SetActive(false);
            }

            if (!SettingsManager.DisableStars) return;


            foreach (GameObject go in __instance.m_Particles) go.SetActive(false);
        }


        [HarmonyPrefix]
        [HarmonyPatch(nameof(FeverEffectManager.CancelFeverEffect))]
        public static bool CancelFeverEffect(FeverEffectManager __instance)
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
}
