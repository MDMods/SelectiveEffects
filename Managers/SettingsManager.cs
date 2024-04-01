using MelonLoader;

namespace SelectiveEffects.Managers;

internal static class SettingsManager
{
    private static readonly string SettingsPath = "UserData/SelectiveEffects.cfg";

    //--------------------------------------------------------------------+
    // Main Category
    //--------------------------------------------------------------------+
    public static bool DisableAllEffects => MainCategory._disableAllEffects.Value;

    public static bool IsEnabled
    {
        get => MainCategory._isEnabled.Value;
        set => MainCategory._isEnabled.Value = value;
    }

    //--------------------------------------------------------------------+
    // Fever Category
    //--------------------------------------------------------------------+
    internal static bool DisableFever => FeverCategory._disableFever.Value
                                         || (DisableBG && DisableStars && DisableTransition);

    public static bool DisableBG => FeverCategory._disableBG.Value;
    public static bool DisableStars => FeverCategory._disableStars.Value;
    public static bool DisableTransition => FeverCategory._disableTransition.Value;

    //--------------------------------------------------------------------+
    // Judgement Category
    //--------------------------------------------------------------------+
    public static bool DisableJudgement => JudgementCategory._disableJudgement.Value
                                           || (DisablePerfects && DisableGreats && DisablePass);

    public static bool MakeJudgementSmaller => JudgementCategory._makeJudgementSmaller.Value;
    public static bool DisablePerfects => JudgementCategory._disablePerfects.Value;
    public static bool DisableGreats => JudgementCategory._disableGreats.Value;
    public static bool DisablePass => JudgementCategory._disablePass.Value;

    //--------------------------------------------------------------------+
    // Hit Category
    //--------------------------------------------------------------------+
    public static bool DisableHitDissapearAnimations => HitCategory._disableHitDissapearAnimations.Value;
    public static bool DisableHitEffects => HitCategory._disableHitEffects.Value;
    public static bool DisableGirlFxAtk => HitCategory._disableGirlFxAtk.Value;
    public static bool DisablePressFx => HitCategory._disablePressFx.Value;

    public static bool DisableHitEnemy => DisableHitDissapearAnimations
                                          && (DisableHitEffects || DisableGirlFxAtk);

    //--------------------------------------------------------------------+
    // Music notes & Hearts Category
    //--------------------------------------------------------------------+
    public static bool DisableMusicNotesFx => MusicHeartsCategory._disableMusicNotesFx.Value;
    public static bool DisableHeartsFx => MusicHeartsCategory._disableHeartsFx.Value;

    //--------------------------------------------------------------------+
    // Misc Category
    //--------------------------------------------------------------------+
    public static bool DisableBossFx => MiscCategory._disableBossFx.Value;
    public static bool DisableDustFx => MiscCategory._disableDustFx.Value;
    public static bool DisableHurtFx => MiscCategory._disableHurtFx.Value;
    public static bool DisableElfinFx => MiscCategory._disableElfinFx.Value;

    internal static void Load()
    {
        MainCategory.Init();
        FeverCategory.Init();
        JudgementCategory.Init();
        HitCategory.Init();
        MusicHeartsCategory.Init();
        MiscCategory.Init();
    }

    private static class MainCategory
    {
        public static MelonPreferences_Entry<bool> _disableAllEffects;
        public static MelonPreferences_Entry<bool> _isEnabled;

        public static void Init()
        {
            var mainCategory = MelonPreferences.CreateCategory("Main");
            mainCategory.SetFilePath(SettingsPath, true, false);

            _isEnabled = mainCategory.CreateEntry("Enabled", true, description: "Enable or disable the mod!");
            _disableAllEffects = mainCategory.CreateEntry("DisableAllEfects", true,
                description: "Takes precedence to the following options.");
        }
    }


    private static class FeverCategory
    {
        public static MelonPreferences_Entry<bool> _disableFever;
        public static MelonPreferences_Entry<bool> _disableBG;
        public static MelonPreferences_Entry<bool> _disableStars;
        public static MelonPreferences_Entry<bool> _disableTransition;


        public static void Init()
        {
            var feverCategory = MelonPreferences.CreateCategory("Fever");
            feverCategory.SetFilePath(SettingsPath, true, false);

            _disableFever = feverCategory.CreateEntry("DisableFever", false);
            _disableBG = feverCategory.CreateEntry("DisableBackground", false);
            _disableStars = feverCategory.CreateEntry("DisableStars", false);
            _disableTransition = feverCategory.CreateEntry("DisableTransition", false);
        }
    }

    private static class JudgementCategory
    {
        public static MelonPreferences_Entry<bool> _disableJudgement;
        public static MelonPreferences_Entry<bool> _makeJudgementSmaller;
        public static MelonPreferences_Entry<bool> _disablePerfects;
        public static MelonPreferences_Entry<bool> _disableGreats;
        public static MelonPreferences_Entry<bool> _disablePass;

        public static void Init()
        {
            var judgementCategory = MelonPreferences.CreateCategory("Judgement");
            judgementCategory.SetFilePath(SettingsPath, true, false);

            _disableJudgement = judgementCategory.CreateEntry("DisableJudgement", false);
            _makeJudgementSmaller = judgementCategory.CreateEntry("MakeJudgementSmaller", false,
                description: "DisableJudgement takes precedence.");
            _disablePerfects = judgementCategory.CreateEntry("DisablePerfects", false);
            _disableGreats = judgementCategory.CreateEntry("DisableGreats", false);
            _disablePass = judgementCategory.CreateEntry("DisablePass", false);
        }
    }

    private static class HitCategory
    {
        public static MelonPreferences_Entry<bool> _disableHitDissapearAnimations;
        public static MelonPreferences_Entry<bool> _disableHitEffects;
        public static MelonPreferences_Entry<bool> _disableGirlFxAtk;
        public static MelonPreferences_Entry<bool> _disablePressFx;

        public static void Init()
        {
            var hitCategory = MelonPreferences.CreateCategory("Hit");
            hitCategory.SetFilePath(SettingsPath, true, false);

            _disableHitDissapearAnimations = hitCategory.CreateEntry("DisableHitDissapearAnimations", false,
                description: "Hit enemies disappear immeadiatly.");
            _disableHitEffects = hitCategory.CreateEntry("DisableHitEffects", false);
            _disableGirlFxAtk = hitCategory.CreateEntry("DisableGirlHitFx", false);
            _disablePressFx = hitCategory.CreateEntry("DisablePressFx", false);
        }
    }

    private static class MusicHeartsCategory
    {
        public static MelonPreferences_Entry<bool> _disableMusicNotesFx;
        public static MelonPreferences_Entry<bool> _disableHeartsFx;

        public static void Init()
        {
            var musicHeartsCategory = MelonPreferences.CreateCategory("MusicHearts");
            musicHeartsCategory.SetFilePath(SettingsPath, true, false);

            _disableMusicNotesFx = musicHeartsCategory.CreateEntry("DisableMusicNotesFx", false,
                description: "Disable music notes points text.");
            _disableHeartsFx = musicHeartsCategory.CreateEntry("DisablHeartsFx", false,
                description: "Disable hearts health gain text.");
        }
    }

    private static class MiscCategory
    {
        public static MelonPreferences_Entry<bool> _disableBossFx;
        public static MelonPreferences_Entry<bool> _disableDustFx;
        public static MelonPreferences_Entry<bool> _disableHurtFx;
        public static MelonPreferences_Entry<bool> _disableElfinFx;

        public static void Init()
        {
            var miscCategory = MelonPreferences.CreateCategory("Misc");
            miscCategory.SetFilePath(SettingsPath, true, false);

            _disableBossFx = miscCategory.CreateEntry("DisableBossFx", false);
            _disableElfinFx = miscCategory.CreateEntry("DisableElfinFx", false);
            _disableDustFx = miscCategory.CreateEntry("DisableDustFx", false);
            _disableHurtFx = miscCategory.CreateEntry("DisableHurtFx", false, description: "Disable hp loss text.");
        }
    }
}