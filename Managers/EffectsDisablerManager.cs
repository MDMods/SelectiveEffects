using MuseDashMirror.Attributes;
using SelectiveEffects.Models;
using UnityEngine;

namespace SelectiveEffects.Managers;

using static SettingsManager;

internal static partial class EffectsDisablerManager
{
    [PnlMenuToggle("EffectsToggleObject", "Disable Effects", nameof(SettingsManager.IsEnabled))]
    private static GameObject DisableEffectsToggle { get; set; }

    internal static List<EffectsCondition> DisableEffectsList { get; private set; }
    internal static HashSet<string> DisabledEffectsUids { get; } = new();
    internal static bool DisableAnyEffect => DisableEffectsList.Count > 0;

    public static void Init()
    {
        if (DisableAllEffects) return;
        DisableEffectsList = new List<EffectsCondition>();

        CheckJudgementOptions();

        if (DisableGirlFxAtk) DisableEffectsList.Add(new GirlFxAtk());
        if (DisablePressFx) DisableEffectsList.Add(new PressFx());

        CheckMusicNotesOptions();
        CheckHeartsOptions();

        if (DisableBossFx) DisableEffectsList.Add(new BossFx());
        if (DisableElfinFx) DisableEffectsList.Add(new ElfinFx());
        if (DisableDustFx) DisableEffectsList.Add(new DustFx());
        if (DisableHurtFx) DisableEffectsList.Add(new HurtFx());
    }

    private static void CheckHeartsOptions()
    {
        if (!DisableHeartsFx) return;
        DisableEffectsList.Add(new FxHp());
        DisableEffectsList.Add(new TxtHp());
    }

    private static void CheckMusicNotesOptions()
    {
        if (!DisableMusicNotesFx) return;
        DisableEffectsList.Add(new FxScore());
        DisableEffectsList.Add(new TxtScore());
    }

    private static void CheckJudgementOptions()
    {
        if (DisableJudgement) return;
        if (DisablePerfects) DisableEffectsList.Add(new Perfects());
        if (DisableGreats) DisableEffectsList.Add(new Greats());
        if (DisablePass) DisableEffectsList.Add(new Pass());
    }
}