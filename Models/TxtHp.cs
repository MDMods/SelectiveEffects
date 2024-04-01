namespace SelectiveEffects.Models;

internal class TxtHp : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("TxtHpGet");
    }
}