using HarmonyLib;
using Il2CppAssets.Scripts.GameCore.GameObjectLogics.GameObjectManager;
using SelectiveEffects.Managers;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(AttackEffectManager), nameof(AttackEffectManager.PlayAttackEffect))]
internal static class HitEffectPatch
{
    internal static void Postfix(AttackEffectManager __instance)
    {
        if (
            !SettingsManager.Get<MainCategory>().IsEnabled
            || !SettingsManager.Get<HitCategory>().DisableHitEffects
        )
            return;

        __instance.m_PlayResult.SetActive(false);
    }
}
