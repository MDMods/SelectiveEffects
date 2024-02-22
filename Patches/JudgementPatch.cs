using HarmonyLib;
using Il2CppFormulaBase;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches
{
    [HarmonyPatch(typeof(StageBattleComponent), nameof(StageBattleComponent.GameStart))]
    internal static class JudgementPatch
    {
        public static void Postfix()
        {
            if (!SettingsManager.DisableJudgement && !SettingsManager.MakeJudgementSmaller) return;
            Transform effectsTransform = GameObject.Find("Effects").transform;

            if (SettingsManager.DisableJudgement)
            {
                effectsTransform.gameObject.SetActive(false);
                return;
            }

            effectsTransform.localScale = new Vector3(0.75f, 1f, 1f);
            effectsTransform.position = new Vector3(-1f, -0.3f, 0f);
        }
    }
}
