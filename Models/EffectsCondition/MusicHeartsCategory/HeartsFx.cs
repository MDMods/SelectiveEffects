using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class HeartsFx : EffectsBaseCondition
{
    private HeartsFx() { }

    internal static HeartsFx Instance { get; } = new();

    protected override bool SettingsValue =>
        SettingsManager.Get<Managers.MusicHeartsCategory>().DisableHeartsFx;

    protected override bool Condition(string s)
    {
        return s.Contains("fx_hp");
    }
}
