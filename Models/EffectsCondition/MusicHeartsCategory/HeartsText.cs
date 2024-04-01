using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class HeartsText : EffectsBaseCondition
{
    private HeartsText()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableHeartsFx;

    internal static HeartsText Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("TxtHpGet");
    }
}