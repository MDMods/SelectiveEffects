using HarmonyLib;
using Il2Cpp;
using SelectiveEffects.Managers;
using Object = UnityEngine.Object;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(BaseEnemyObjectController), nameof(BaseEnemyObjectController.OnControllerAttacked))]
internal static class DisappearAnimationPatch
{
    internal static void Postfix(BaseEnemyObjectController __instance)
    {
        if (!SettingsManager.IsEnabled) return;

        if (SettingsManager.DisableAllEffects || SettingsManager.DisableHitEnemy)
        {
            __instance.gameObject.SetActive(false);
            return;
        }

        if (SettingsManager.DisableHitEffects)
        {
            var outFX = __instance.transform.FindChild("out_fx")?.gameObject;
            if (outFX) Object.Destroy(outFX);
        }

        if (!SettingsManager.DisableHitDisappearAnimations) return;
        __instance.m_SkeletonAnimation.skeleton.a = 0f;
    }
}