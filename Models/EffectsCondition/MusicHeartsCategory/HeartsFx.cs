using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MusicHeartsCategory;

internal class HeartsFx : EffectsBaseCondition
{
    private HeartsFx()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableHeartsFx;

    internal static HeartsFx Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("fx_hp");
    }
}