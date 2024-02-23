namespace SelectiveEffects.Managers
{
    using static SettingsManager;

    internal static class EffectsDisablerManager
    {
        public static List<EffectsCondition> effectsDisablerList;
        public static bool AnyEffect = false;

        public static void Init()
        {
            if (DisableAllEffects) return;
            effectsDisablerList = new();

            if (!DisableJudgement)
            {
                if (DisablePerfects) effectsDisablerList.Add(new Perfects());
                if (DisableGreats) effectsDisablerList.Add(new Greats());
                if (DisablePass) effectsDisablerList.Add(new Pass());
            }

            if (DisableGirlFxAtk) effectsDisablerList.Add(new GirlFxAtk());
            if (DisablePressFx) effectsDisablerList.Add(new PressFx());
            if (DisableMusicNotesFx)
            {
                effectsDisablerList.Add(new FxScore());
                effectsDisablerList.Add(new TxtScore());
            }
            if (DisableHeartsFx)
            {
                effectsDisablerList.Add(new FxHp());
                effectsDisablerList.Add(new TxtHp());
            }
            if (DisableBossFx) effectsDisablerList.Add(new BossFx());
            if (DisableElfinFx) effectsDisablerList.Add(new ElfinFx());
            if (DisableDustFx) effectsDisablerList.Add(new DustFx());
            if (DisableHurtFx) effectsDisablerList.Add(new HurtFx());

            AnyEffect = effectsDisablerList.Count > 0;
        }
    }

    internal abstract class EffectsCondition
    {
        public abstract bool Condition(string s);
    }

    internal class Perfects : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("Perfect");
        }
    }

    internal class Greats : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("Great");
        }
    }

    internal class Pass : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("Pass");
        }
    }

    internal class GirlFxAtk : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("girl_fx_atk");
        }
    }

    internal class PressFx : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("press_top_fx");
        }
    }

    internal class FxScore : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("fx_score");
        }
    }

    internal class TxtScore : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("TxtScoreGet");
        }
    }

    internal class TxtHp : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("TxtHpGet");
        }
    }

    internal class FxHp : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("fx_hp");
        }
    }

    internal class BossFx : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("boss");
        }
    }

    internal class ElfinFx : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("elfin");
        }
    }

    internal class DustFx : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("dust_fx");
        }
    }

    internal class HurtFx : EffectsCondition
    {
        public override bool Condition(string s)
        {
            return s.Contains("TxtHurt");
        }
    }
}