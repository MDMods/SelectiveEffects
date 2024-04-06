using MuseDashMirror.Attributes;
using SelectiveEffects.Models;
using SelectiveEffects.Models.EffectsCondition.HitCategory;
using SelectiveEffects.Models.EffectsCondition.JudgementCategory;
using SelectiveEffects.Models.EffectsCondition.MiscCategory;
using SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;
using UnityEngine;
using UnityEngine.UI;

namespace SelectiveEffects.Managers;

internal static partial class EffectsDisablerManager
{
    static EffectsDisablerManager()
    {
        Load();
    }

    [PnlMenuToggle("EffectsToggleObject", "Disable Effects", nameof(SettingsManager.IsEnabled))]
    private static GameObject DisableEffectsToggle { get; set; }


    internal static Dictionary<string, Action<GameObject>> DisabledEffectsUids =>
        EffectsBaseCondition.DisabledEffectsUids;

    internal static List<EffectsBaseCondition> DisableEffectsList => EffectsBaseCondition.DisableEffectsList;
    internal static bool DisableAnyEffect => DisableEffectsList.Count > 0;

    internal static void Load()
    {
        DisableEffectsList.Clear();
        DisabledEffectsUids.Clear();

        if (SettingsManager.DisableAllEffects) return;

        // JudgementCategory
        Perfects.Instance.CheckAndAddInstance();
        Greats.Instance.CheckAndAddInstance();
        Pass.Instance.CheckAndAddInstance();
        JudgementSize.Instance.CheckAndAddInstance();

        // HitCategory
        GirlFxAtk.Instance.CheckAndAddInstance();
        PressFx.Instance.CheckAndAddInstance();

        // MusicHeartsCategory
        MusicNotesFx.Instance.CheckAndAddInstance();
        MusicNotesText.Instance.CheckAndAddInstance();
        HeartsFx.Instance.CheckAndAddInstance();
        HeartsText.Instance.CheckAndAddInstance();

        // MiscCategory
        BossFx.Instance.CheckAndAddInstance();
        ElfinFx.Instance.CheckAndAddInstance();
        DustFx.Instance.CheckAndAddInstance();
        HurtFx.Instance.CheckAndAddInstance();
    }

    internal static void ReloadToggle()
    {
        if (!DisableEffectsToggle) return;
        
        var toggleComp = DisableEffectsToggle.GetComponent<Toggle>();
        if (!toggleComp) return;
        
        toggleComp.Set(SettingsManager.IsEnabled);
    }
}