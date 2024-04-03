using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.GameCore.HostComponent;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppFormulaBase;
using SelectiveEffects.Managers;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(JudgeDisplay), nameof(JudgeDisplay.OnEnable))]
internal static class EarlyLatePatch
{
    internal static void Postfix(JudgeDisplay __instance)
    {
        if (!SettingsManager.IsEnabled
            || SettingsManager.DisableAllEffects
            || SettingsManager.DisablePerfects
            || !SettingsManager.DisablePerfectPerfects
            || !Singleton<StageBattleComponent>.instance.isInGame) return;

        __instance.gameObject.SetActive(BattleRoleAttributeComponent.instance.judgeState != 0);
    }
}