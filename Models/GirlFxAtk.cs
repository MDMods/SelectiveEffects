namespace SelectiveEffects.Models;

internal class GirlFxAtk : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("girl_fx_atk");
    }
}