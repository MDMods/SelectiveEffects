namespace SelectiveEffects.Models;

internal class Perfects : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("Perfect");
    }
}