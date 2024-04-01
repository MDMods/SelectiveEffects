using SelectiveEffects.Managers;

namespace SelectiveEffects.Models;

internal abstract class EffectsCondition
{
    protected abstract bool Condition(string s);

    public virtual void Action(string s)
    {
        EffectsDisablerManager.DisabledEffectsUids.Add(s);
        //effectPrefab.AddComponent<DisableEffectComponent>();
    }

    public bool CheckDo(string uid)
    {
        if (!Condition(uid)) return false;

        Action(uid);
        return true;
    }
}