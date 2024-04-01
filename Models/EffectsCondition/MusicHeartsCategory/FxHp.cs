using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class FxHp : EffectsBaseCondition
{
    private FxHp()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableHeartsFx;

    internal static FxHp Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("fx_hp");
    }
}