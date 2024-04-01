using HarmonyLib;
using Il2Cpp;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches
{
    [HarmonyPatch(typeof(BaseEnemyObjectController))]
    internal static class DisappearAnimationPatch
    {
        [HarmonyPatch(nameof(BaseEnemyObjectController.OnControllerAttacked))]
        public static void Postfix(BaseEnemyObjectController __instance)
        {
            if (!SettingsManager.IsEnabled) return;

            if (SettingsManager.DisableAllEffects || SettingsManager.DisableHitEnemy)
            {
                __instance.gameObject.SetActive(false);
                return;
            }

            if (SettingsManager.DisableHitEffects)
            {
                GameObject out_fx = __instance.transform.FindChild("out_fx")?.gameObject;
                if (out_fx) UnityEngine.Object.Destroy(out_fx);
            }

            if (!SettingsManager.DisableHitDissapearAnimations) return;
            __instance.m_SkeletonAnimation.skeleton.a = 0f;
        }
    }
}
