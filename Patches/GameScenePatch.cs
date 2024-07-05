using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.GameCore.GameObjectLogics.ExtraControl;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSpine.Unity;
using MelonLoader;
using SelectiveEffects.Managers;

namespace SelectiveEffects;

[HarmonyPatch]
internal static class GameScenePatch
{
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
        // ! Fix this method
        if (
            !SettingsManager.Get<MainCategory>().IsEnabled
            || !SettingsManager.Get<GameSceneCategory>().DisableGirl
        )
            return;

        if (!__instance.name.InvariantContains("shadow"))
            return;

        __instance.gameObject.SetActive(false);
    }
}
