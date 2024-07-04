using HarmonyLib;
using Il2Cpp;
using Il2CppSpine.Unity;
using SelectiveEffects.Managers;

namespace SelectiveEffects;

[HarmonyPatch]
internal static class GameScenePatch
{
    [HarmonyPatch(typeof(GirlActionController), nameof(GirlActionController.Init))]
    [HarmonyPostfix]
    internal static void GirlInitPostfix(GirlActionController __instance)
    {
        if (!SettingsManager.Get<GameScene>().DisableGirl)
            return;
        // ! Check SHADOW
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
}
