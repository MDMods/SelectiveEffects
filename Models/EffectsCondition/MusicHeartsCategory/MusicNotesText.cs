using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class MusicNotesText : EffectsBaseCondition
{
    private MusicNotesText() { }

    internal static MusicNotesText Instance { get; } = new();

    protected override bool SettingsValue =>
        SettingsManager.Get<Managers.MusicHeartsCategory>().DisableMusicNotesFx;

    protected override bool Condition(string s)
    {
        return s.Contains("TxtScoreGet");
    }
}
