using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class HeartsText : EffectsBaseCondition
{
    private HeartsText() { }

    internal static HeartsText Instance { get; } = new();

    protected override bool SettingsValue =>
        SettingsManager.Get<Managers.MusicHearts>().DisableHeartsFx;

    protected override bool Condition(string s)
    {
        return s.Contains("TxtHpGet");
    }
}
