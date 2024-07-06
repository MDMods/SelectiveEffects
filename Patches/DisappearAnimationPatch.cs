using HarmonyLib;
using Il2Cpp;
using SelectiveEffects.Managers;
using Object = UnityEngine.Object;

namespace SelectiveEffects.Patches;

[HarmonyPatch(
    typeof(BaseEnemyObjectController),
    nameof(BaseEnemyObjectController.OnControllerAttacked)
)]
internal static class DisappearAnimationPatch
{
    internal static void Postfix(BaseEnemyObjectController __instance)
    {
        var mainCategory = SettingsManager.Get<Managers.MainCategory>();
        var hitCategory = SettingsManager.Get<Hit>();
        if (!mainCategory.IsEnabled)
            return;

        if (mainCategory.DisableAllEffects || hitCategory.DisableHitEnemy)
        {
            __instance.gameObject.SetActive(false);
            return;
        }

        if (hitCategory.DisableHitEffects)
        {
            var outFX = __instance.transform.FindChild("out_fx")?.gameObject;
            if (outFX)
                Object.Destroy(outFX);
        }

        if (!hitCategory.DisableHitDisappearAnimations)
            return;
        __instance.m_SkeletonAnimation.skeleton.a = 0f;
    }
}
