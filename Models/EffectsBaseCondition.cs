namespace SelectiveEffects.Models;

internal abstract class EffectsBaseCondition
{
    internal static List<EffectsBaseCondition> DisableEffectsList { get; } = new();

    internal static HashSet<string> DisabledEffectsUids { get; } = new();

    protected abstract bool SettingsValue { get; }

    internal void CheckAndAddInstance()
    {
        if (!SettingsValue) return;

        DisableEffectsList.Add(this);
    }

    protected abstract bool Condition(string s);

    protected virtual void Action(string s)
    {
        DisabledEffectsUids.Add(s);
    }

    internal void CheckConditionAndAddUid(string uid)
    {
        if (!Condition(uid)) return;

        Action(uid);
    }
}