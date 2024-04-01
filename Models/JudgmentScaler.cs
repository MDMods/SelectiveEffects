using MelonLoader;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Models;

[RegisterTypeInIl2Cpp]
internal class JudgmentScaler : MonoBehaviour
{
    //private static Vector3 _newScale = new(0.5f, 0.5f);
    public JudgmentScaler(IntPtr ptr) : base(ptr)
    {
    }
    
    public void Awake()
    {
        if (SettingsManager.MakeJudgementSmaller) return;

        enabled = false;
    }

    public void LateUpdate()
    {
        transform.localScale *= 0.5f;
    }
}