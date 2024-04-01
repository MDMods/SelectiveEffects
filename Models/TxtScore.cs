namespace SelectiveEffects.Models;

internal class TxtScore : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("TxtScoreGet");
    }
}