using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Models.EffectsCondition.JudgementCategory;

// Unused
internal class JudgementSize : EffectsBaseCondition
{
    private JudgementSize() { }

    internal static JudgementSize Instance { get; } = new();

    protected override bool SettingsValue =>
        SettingsManager.Get<Managers.JudgementCategory>().MakeJudgementSmaller;

    protected override bool Condition(string s)
    {
        return s.Contains("Img");
    }

    protected override void FoundAction(GameObject go)
    {
        if (!go.name.Contains("Gold"))
        {
            if (go.TryGetComponent(out JudgmentScaler _))
                return;

            go.AddComponent<JudgmentScaler>();

            return;
        }

        for (var i = 0; i < go.transform.childCount; i++)
        {
            var child = go.transform.GetChild(i);

            if (child.TryGetComponent(out JudgmentScaler _))
                return;
            child.gameObject.AddComponent<JudgmentScaler>();
        }
    }
}
