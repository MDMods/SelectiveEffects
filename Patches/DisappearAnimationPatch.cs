using HarmonyLib;
using Il2Cpp;
using SelectiveEffects.Managers;
using Object = UnityEngine.Object;

namespace SelectiveEffects.Patches;

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
            var out_fx = __instance.transform.FindChild("out_fx")?.gameObject;
            if (out_fx) Object.Destroy(out_fx);
        }

        if (!SettingsManager.DisableHitDisappearAnimations) return;
        __instance.m_SkeletonAnimation.skeleton.a = 0f;
    }
}