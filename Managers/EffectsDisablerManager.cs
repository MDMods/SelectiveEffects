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
    [PnlMenuToggle("EffectsToggleObject", "Disable Effects", nameof(IsEnabled))]
    private static GameObject DisableEffectsToggle { get; set; }


    internal static HashSet<string> DisabledEffectsUids => EffectsBaseCondition.DisabledEffectsUids;
    internal static List<EffectsBaseCondition> DisableEffectsList => EffectsBaseCondition.DisableEffectsList;
    internal static bool DisableAnyEffect => DisableEffectsList.Count > 0;

    public static void Init()
    {
        if (DisableAllEffects) return;
        
        Perfects.Instance.CheckAndAddInstance();
        Greats.Instance.CheckAndAddInstance();
        Pass.Instance.CheckAndAddInstance();

        GirlFxAtk.Instance.CheckAndAddInstance();
        PressFx.Instance.CheckAndAddInstance();

        FxScore.Instance.CheckAndAddInstance();
        TxtScore.Instance.CheckAndAddInstance();

        FxHp.Instance.CheckAndAddInstance();
        TxtHp.Instance.CheckAndAddInstance();

        BossFx.Instance.CheckAndAddInstance();
        ElfinFx.Instance.CheckAndAddInstance();
        DustFx.Instance.CheckAndAddInstance();
        HurtFx.Instance.CheckAndAddInstance();
    }
}