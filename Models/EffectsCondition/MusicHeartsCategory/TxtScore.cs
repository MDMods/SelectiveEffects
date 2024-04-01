using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class TxtScore : EffectsBaseCondition
{
    private TxtScore()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableMusicNotesFx;

    internal static TxtScore Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("TxtScoreGet");
    }
}