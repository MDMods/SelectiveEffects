namespace SelectiveEffects.Models;

internal class Pass : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("Pass");
    }
}