using MuseDashMirror.Attributes;
using SelectiveEffects.Models;
using SelectiveEffects.Models.EffectsCondition.HitCategory;
using SelectiveEffects.Models.EffectsCondition.JudgementCategory;
using SelectiveEffects.Models.EffectsCondition.MiscCategory;
using SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;
using UnityEngine;

namespace SelectiveEffects.Managers;

using static SettingsManager;

internal static partial class EffectsDisablerManager
{
    [PnlMenuToggle("EffectsToggleObject", "Disable Effects", nameof(SettingsManager.IsEnabled))]
    private static GameObject DisableEffectsToggle { get; set; }

    
    internal static Dictionary<string, Action<GameObject>> DisabledEffectsUids =>
        EffectsBaseCondition.DisabledEffectsUids;

    internal static List<EffectsBaseCondition> DisableEffectsList => EffectsBaseCondition.DisableEffectsList;
    internal static bool DisableAnyEffect => DisableEffectsList.Count > 0;

    internal static void Init()
    {
        if (DisableAllEffects) return;

        Perfects.Instance.CheckAndAddInstance();
        Greats.Instance.CheckAndAddInstance();
        Pass.Instance.CheckAndAddInstance();
        JudgementSize.Instance.CheckAndAddInstance();

        GirlFxAtk.Instance.CheckAndAddInstance();
        PressFx.Instance.CheckAndAddInstance();

        MusicNotesFx.Instance.CheckAndAddInstance();
        MusicNotesText.Instance.CheckAndAddInstance();

        HeartsFx.Instance.CheckAndAddInstance();
        HeartsText.Instance.CheckAndAddInstance();

        BossFx.Instance.CheckAndAddInstance();
        ElfinFx.Instance.CheckAndAddInstance();
        DustFx.Instance.CheckAndAddInstance();
        HurtFx.Instance.CheckAndAddInstance();
    }
}