using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class MusicNotesText : EffectsBaseCondition
{
    private MusicNotesText()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableMusicNotesFx;

    internal static MusicNotesText Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("TxtScoreGet");
    }
}