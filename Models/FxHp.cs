namespace SelectiveEffects.Models;

internal class FxHp : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("fx_hp");
    }
}