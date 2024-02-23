using MelonLoader;

namespace SelectiveEffects.Managers
{
    internal class SettingsManager
    {
        internal static string SettingsPath = "UserData/SelectiveEffects.cfg";

        //--------------------------------------------------------------------+
        // Main Category
        //--------------------------------------------------------------------+
        public static bool DisableAllEffects => MainCategory._disableAllEffects.Value;
        public static bool Enabled
        {
            get => MainCategory._enabled.Value;
            set => MainCategory._enabled.Value = value;
        }

        internal class MainCategory
        {
            public static MelonPreferences_Entry<bool> _disableAllEffects;
            public static MelonPreferences_Entry<bool> _enabled;

            public static void Init()
            {
                MelonPreferences_Category mainCategory = MelonPreferences.CreateCategory("Main");
                mainCategory.SetFilePath(SettingsPath);

                _enabled = mainCategory.CreateEntry<bool>("Enabled", true, description: "Enable or disable the mod!");
                _disableAllEffects = mainCategory.CreateEntry<bool>("DisableAllEfects", true, description: "Takes precedence to the following options.");
            }

        }

        //--------------------------------------------------------------------+
        // Judgement Category
        //--------------------------------------------------------------------+
        public static bool DisableJudgement => JudgementCategory._disableJudgement.Value;
        public static bool MakeJudgementSmaller => JudgementCategory._makeJudgementSmaller.Value;

        internal class JudgementCategory
        {
            public static MelonPreferences_Entry<bool> _disableJudgement;
            public static MelonPreferences_Entry<bool> _makeJudgementSmaller;

            public static void Init()
            {
                MelonPreferences_Category judgementCategory = MelonPreferences.CreateCategory("Judgement");
                judgementCategory.SetFilePath(SettingsPath);

                _disableJudgement = judgementCategory.CreateEntry<bool>("DisableJudgement", false);
                _makeJudgementSmaller = judgementCategory.CreateEntry<bool>("MakeJudgementSmaller", false, description: "DisableJudgement takes precedence.");
            }
        }

        //--------------------------------------------------------------------+
        // Hit Category
        //--------------------------------------------------------------------+
        public static bool DisableHitDissapearAnimations => HitCategory._disableHitDissapearAnimations.Value;
        public static bool DisableHitEffects => HitCategory._disableHitEffects.Value;
        public static bool DisableGirlFxAtk => HitCategory._disableGirlFxAtk.Value;
        public static bool DisablePressFx => HitCategory._disablePressFx.Value;

        internal class HitCategory
        {
            public static MelonPreferences_Entry<bool> _disableHitDissapearAnimations;
            public static MelonPreferences_Entry<bool> _disableHitEffects;
            public static MelonPreferences_Entry<bool> _disableGirlFxAtk;
            public static MelonPreferences_Entry<bool> _disablePressFx;

            public static void Init()
            {
                MelonPreferences_Category hitCategory = MelonPreferences.CreateCategory("Hit");
                hitCategory.SetFilePath(SettingsPath);

                _disableHitDissapearAnimations = hitCategory.CreateEntry<bool>("DisableHitDissapearAnimations", false, description: "Hit enemies disappear immeadiatly.");
                _disableHitEffects = hitCategory.CreateEntry<bool>("DisableHitEffects", false);
                _disableGirlFxAtk = hitCategory.CreateEntry<bool>("DisableGirlHitFx", false);
                _disablePressFx = hitCategory.CreateEntry<bool>("DisablePressFx", false);
            }
        }

        //--------------------------------------------------------------------+
        // Music notes & Hearts Category
        //--------------------------------------------------------------------+
        public static bool DisableMusicNotesFx => MusicHeartsCategory._disableMusicNotesFx.Value;
        public static bool DisableHeartsFx => MusicHeartsCategory._disableHeartsFx.Value;

        internal class MusicHeartsCategory
        {
            public static MelonPreferences_Entry<bool> _disableMusicNotesFx;
            public static MelonPreferences_Entry<bool> _disableHeartsFx;

            public static void Init()
            {
                MelonPreferences_Category musicHeartsCategory = MelonPreferences.CreateCategory("MusicHearts");
                musicHeartsCategory.SetFilePath(SettingsPath);

                _disableMusicNotesFx = musicHeartsCategory.CreateEntry<bool>("DisableMusicNotesFx", false, description: "Disable music notes points text.");
                _disableHeartsFx = musicHeartsCategory.CreateEntry<bool>("DisablHeartsFx", false, description: "Disable hearts health gain text.");
            }
        }

        public static bool DisableBossFx => MiscCategory._disableBossFx.Value;
        public static bool DisableDustFx => MiscCategory._disableDustFx.Value;
        public static bool DisableHurtFx => MiscCategory._disableHurtFx.Value;

        internal class MiscCategory
        {
            public static MelonPreferences_Entry<bool> _disableBossFx;
            public static MelonPreferences_Entry<bool> _disableDustFx;
            public static MelonPreferences_Entry<bool> _disableHurtFx;

            public static void Init()
            {
                MelonPreferences_Category miscCategory = MelonPreferences.CreateCategory("Misc");
                miscCategory.SetFilePath(SettingsPath);

                _disableBossFx = miscCategory.CreateEntry<bool>("DisableBossFx", false);
                _disableDustFx = miscCategory.CreateEntry<bool>("DisableDustFx", false);
                _disableHurtFx = miscCategory.CreateEntry<bool>("DisableHurtFx", false, description: "Disable hp loss text.");
            }
        }

        public static bool DisableHitEnemy => DisableHitDissapearAnimations && DisableHitEffects;

        internal static void Load()
        {
            MainCategory.Init();
            JudgementCategory.Init();
            HitCategory.Init();
            MusicHeartsCategory.Init();
            MiscCategory.Init();
        }
    }
}