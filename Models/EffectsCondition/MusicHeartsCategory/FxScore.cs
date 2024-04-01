using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class FxScore : EffectsBaseCondition
{
    private FxScore()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableMusicNotesFx;

    internal static FxScore Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("fx_score");
    }
}