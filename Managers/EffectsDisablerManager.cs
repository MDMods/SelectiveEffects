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

        /*
        CheckJudgementOptions();

        if (DisableGirlFxAtk) DisableEffectsList.Add(new GirlFxAtk());
        if (DisablePressFx) DisableEffectsList.Add(new PressFx());

        CheckMusicNotesOptions();
        CheckHeartsOptions();

        if (DisableBossFx) DisableEffectsList.Add(new BossFx());
        if (DisableElfinFx) DisableEffectsList.Add(new ElfinFx());
        if (DisableDustFx) DisableEffectsList.Add(new DustFx());
        if (DisableHurtFx) DisableEffectsList.Add(new HurtFx());
        */
        /*
        new Perfects();
        new Greats();
        new Pass();

        new GirlFxAtk();
        new PressFx();

        new FxScore();
        new TxtScore();

        new FxHp();
        new TxtHp();

        new BossFx();
        new ElfinFx();
        new DustFx();
        new HurtFx();
        */
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

    /*
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
    */
}