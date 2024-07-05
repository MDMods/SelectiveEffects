using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.GameCore.GameObjectLogics.ExtraControl;
using Il2CppSpine.Unity;
using MelonLoader;
using SelectiveEffects.Managers;

namespace SelectiveEffects;

[HarmonyPatch]
internal static class GameScenePatch
{
    [HarmonyPatch(typeof(GirlActionController), nameof(GirlActionController.Init))]
    [HarmonyPostfix]
    internal static void GirlInitPostfix(GirlActionController __instance)
    {
        if (!SettingsManager.Get<GameSceneCategory>().DisableGirl)
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
        if (!SettingsManager.Get<GameSceneCategory>().DisableGirl)
            return;
        if (!__instance.name.InvariantContains("shadow"))
            return;

        __instance.gameObject.SetActive(false);
    }
}
