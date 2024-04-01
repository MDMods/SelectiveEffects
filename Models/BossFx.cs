namespace SelectiveEffects.Models;

internal class BossFx : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("boss");
    }
}