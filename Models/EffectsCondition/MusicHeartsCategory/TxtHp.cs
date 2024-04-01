using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class TxtHp : EffectsBaseCondition
{
    private TxtHp()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableHeartsFx;

    internal static TxtHp Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("TxtHpGet");
    }
}