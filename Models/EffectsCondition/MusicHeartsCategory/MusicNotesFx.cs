using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class MusicNotesFx : EffectsBaseCondition
{
    private MusicNotesFx() { }

    internal static MusicNotesFx Instance { get; } = new();

    protected override bool SettingsValue =>
        SettingsManager.Get<Managers.MusicHearts>().DisableMusicNotesFx;

    protected override bool Condition(string s)
    {
        return s.Contains("fx_score");
    }
}
