using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.GameCore.GameObjectLogics.ExtraControl;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSpine.Unity;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches;

[HarmonyPatch]
internal static class GameScenePatch
{
    [HarmonyPatch(typeof(NeonEggIncubationHandle), nameof(NeonEggIncubationHandle.OnDestroy))]
    [HarmonyPostfix]
    internal static void ElfinNeonEggPostfix(NeonEggIncubationHandle __instance)
    {
        if (
            !SettingsManager.Get<MainCategory>().IsEnabled
            || !SettingsManager.Get<GameSceneCategory>().DisableElfin
        )
            return;

        var go = __instance.gameObject.transform.parent;

        // Search for the new elfin transform
        Transform newElfin = null;
        for (var i = 0; i < go.childCount; i++)
        {
            var child = go.GetChild(i);
            if (!child.name.InvariantContains("egg"))
            {
                newElfin = child;
                break;
            }
        }

        if (newElfin == null)
            return;

        if (!newElfin.TryGetComponent(out SkeletonMecanim skMecanim))
            return;

        skMecanim.skeleton.a = 0;
    }

    [HarmonyPatch(
        typeof(ElfinCreate),
        nameof(ElfinCreate.OnBattleStart),
        typeof(Il2CppSystem.Object),
        typeof(Il2CppSystem.Object),
        typeof(Il2CppReferenceArray<Il2CppSystem.Object>)
    )]
    [HarmonyPostfix]
    internal static void ElfinPostfix(ElfinCreate __instance)
    {
        if (
            !SettingsManager.Get<MainCategory>().IsEnabled
            || !SettingsManager.Get<GameSceneCategory>().DisableElfin
        )
            return;

        var skMechanism = __instance.m_SkeletonMecanim;
        if (!skMechanism)
            return;

        skMechanism.skeleton.a = 0;
    }

    [HarmonyPatch(typeof(GirlActionController), nameof(GirlActionController.Init))]
    [HarmonyPostfix]
    internal static void GirlInitPostfix(GirlActionController __instance)
    {
        if (
            !SettingsManager.Get<MainCategory>().IsEnabled
            || !SettingsManager.Get<GameSceneCategory>().DisableGirl
        )
            return;
        var girlSk = __instance.go?.GetComponent<SkeletonAnimation>();
        if (girlSk)
        {
            girlSk.skeleton.a = 0;
        }

        var ghostSk = __instance.ghostSk;
        if (ghostSk)
        {
            ghostSk.skeleton.a = 0;
        }
    }

    [HarmonyPatch(typeof(RoleBattleSubControl), nameof(RoleBattleSubControl.Init))]
    [HarmonyPostfix]
    internal static void GirlShadowPostfix(RoleBattleSubControl __instance)
    {
        if (
            !SettingsManager.Get<MainCategory>().IsEnabled
            || !SettingsManager.Get<GameSceneCategory>().DisableGirl
        )
            return;

        if (!__instance.name.InvariantContains("shadow"))
            return;

        var skAnim = __instance.m_SkAnimator;
        if (!skAnim)
            return;
        skAnim.skeleton.a = 0;
    }
}
