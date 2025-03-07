using HarmonyLib;
using Il2CppAssets.Scripts.UI.Panels;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(PnlBattle), nameof(PnlBattle.GameStart))]
internal static class InterfacePatch
{
    private static readonly Interface Interface = SettingsManager.Get<Interface>();

    private static void Prefix()
    {
        var pnlBattleOthers = GameObject.Find("PnlBattleOthers");
        var up = pnlBattleOthers.transform.Find("Up");

        if (Interface.DisableHealthBar)
        {
            var healthBar = pnlBattleOthers.transform.Find("Below").gameObject;
            if (healthBar != null)
                healthBar.SetActive(false);
        }

        if (Interface.DisableScore)
        {
            var score = pnlBattleOthers.transform.Find("Score").gameObject;
            if (score != null)
                score.SetActive(false);
        }

        if (Interface.DisableCombo)
        {
            var combo = GameObject.Find("PnlCommonUI");
            if (combo != null)
                combo.SetActive(false);

            combo = GameObject.Find("PnlNewComboUI");
            if (combo != null)
                combo.SetActive(false);
        }

        if (Interface.DisablePauseButton)
        {
            var pauseButton = up.Find("BtnPause").GetChild(0).gameObject;
            if (pauseButton != null)
                pauseButton.SetActive(false);
        }

        if (!Interface.DisableProgressBar) return;
        var progressBar = up.Find("SldStageProgress").gameObject;
        if (progressBar != null)
            progressBar.SetActive(false);
    }
}
