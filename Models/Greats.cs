namespace SelectiveEffects.Models;

internal class Greats : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("Great");
    }
}