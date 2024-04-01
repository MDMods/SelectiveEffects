namespace SelectiveEffects.Models;

internal class HurtFx : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("TxtHurt");
    }
}