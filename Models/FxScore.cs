namespace SelectiveEffects.Models;

internal class FxScore : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("fx_score");
    }
}