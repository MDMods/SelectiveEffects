namespace SelectiveEffects.Models;

internal class ElfinFx : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("elfin");
    }
}