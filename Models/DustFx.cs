namespace SelectiveEffects.Models;

internal class DustFx : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("dust_fx");
    }
}