using MelonLoader;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Models;

[RegisterTypeInIl2Cpp]
internal class JudgmentScaler : MonoBehaviour
{
    public JudgmentScaler(IntPtr ptr) : base(ptr)
    {
    }

    public void Awake()
    {
        if (SettingsManager.IsEnabled || SettingsManager.MakeJudgementSmaller) return;

        enabled = false;
    }

    public void LateUpdate()
    {
        transform.localScale *= (float)SettingsManager.ScalePercentage / 100;
    }
}