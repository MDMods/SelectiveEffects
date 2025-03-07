using HarmonyLib;
using Il2CppAssets.Scripts.UI.Panels;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(PnlBattle), nameof(PnlBattle.GameStart))]
internal static class InterfacePatch
{
    private static readonly Interface Interface = SettingsManager.Get<Interface>();
    private static readonly MainCategory MainCategory = SettingsManager.Get<MainCategory>();

    private static void Prefix()
    {
        if (!MainCategory.IsEnabled)
            return;

        var pnlBattleOthers = GameObject.Find("PnlBattleOthers");
        var up = pnlBattleOthers?.transform.Find("Up");

        if (Interface.DisableHealthBar)
        {
            var healthBar = pnlBattleOthers?.transform.Find("Below")?.gameObject;
            healthBar?.SetActive(false);
        }

        if (Interface.DisableScore)
        {
            var score = pnlBattleOthers?.transform.Find("Score")?.gameObject;
            score?.SetActive(false);
        }

        if (Interface.DisableCombo)
        {
            var combo = GameObject.Find("PnlCommonUI");
            combo?.SetActive(false);

            combo = GameObject.Find("PnlNewComboUI");
            combo?.SetActive(false);
        }

        if (Interface.DisablePauseButton)
        {
            var pauseButton = up?.Find("BtnPause")?.GetChild(0)?.gameObject;
            pauseButton?.SetActive(false);
        }

        if (!Interface.DisableProgressBar)
            return;
        var progressBar = up?.Find("SldStageProgress")?.gameObject;
        progressBar?.SetActive(false);
    }
}
