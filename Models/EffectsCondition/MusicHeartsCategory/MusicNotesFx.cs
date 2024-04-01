using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class MusicNotesFx : EffectsBaseCondition
{
    private MusicNotesFx()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableMusicNotesFx;

    internal static MusicNotesFx Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("fx_score");
    }
}