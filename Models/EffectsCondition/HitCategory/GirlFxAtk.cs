using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Models.EffectsCondition.HitCategory;

internal class GirlFxAtk : EffectsBaseCondition
{
    private GirlFxAtk() { }

    internal static GirlFxAtk Instance { get; } = new();

    protected override bool SettingsValue
    {
        get
        {
            var hitCategory = SettingsManager.Get<Managers.Hit>();
            return hitCategory.DisableGirlFxAtk || hitCategory.DisableGirlAtkParticles;
        }
    }

    protected override bool Condition(string s)
    {
        return s.Contains("girl_fx_atk");
    }

    protected override void FoundAction(GameObject go)
    {
        if (SettingsManager.Get<Managers.Hit>().DisableGirlFxAtk)
        {
            base.FoundAction(go);
            return;
        }

        var starParticles = go.transform.Find("fx_star");
        if (starParticles is null)
            return;
        starParticles.gameObject.SetActive(false);
    }
}
