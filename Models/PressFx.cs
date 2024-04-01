namespace SelectiveEffects.Models;

internal class PressFx : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("press_top_fx");
    }
}