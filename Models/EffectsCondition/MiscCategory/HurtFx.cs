﻿using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MiscCategory;

internal class HurtFx : EffectsBaseCondition
{
    private HurtFx() { }

    internal static HurtFx Instance { get; } = new();

    protected override bool SettingsValue => SettingsManager.Get<Managers.Misc>().DisableHurtFx;

    protected override bool Condition(string s)
    {
        return s.Contains("TxtHurt");
    }
}
