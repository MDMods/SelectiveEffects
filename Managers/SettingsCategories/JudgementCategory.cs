using MelonLoader;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    //--------------------------------------------------------------------+
    // Judgement Category
    //--------------------------------------------------------------------+
    internal static bool DisableJudgement => JudgementCategory._disableJudgement.Value
                                             || (DisablePerfects && DisableGreats && DisablePass)
                                             || ScalePercentage == 0;

    internal static bool DisablePerfects => JudgementCategory._disablePerfects.Value;
    internal static bool DisableGreats => JudgementCategory._disableGreats.Value;
    internal static bool DisablePass => JudgementCategory._disablePass.Value;
    internal static bool MakeJudgementSmaller => JudgementCategory._makeJudgementSmaller.Value;
    internal static int ScalePercentage => JudgementCategory._scalePercentage.Value;

    private static class JudgementCategory
    {
        private static readonly MelonPreferences_Category Category;
        internal static readonly MelonPreferences_Entry<bool> _disableJudgement;
        internal static readonly MelonPreferences_Entry<bool> _disablePerfects;
        internal static readonly MelonPreferences_Entry<bool> _disableGreats;
        internal static readonly MelonPreferences_Entry<bool> _disablePass;
        internal static readonly MelonPreferences_Entry<bool> _makeJudgementSmaller;
        internal static readonly MelonPreferences_Entry<int> _scalePercentage;

        static JudgementCategory()
        {
            Category = MelonPreferences.CreateCategory("Judgement");
            Category.SetFilePath(SettingsPath, false, false);

            _disableJudgement = Category.CreateEntry("DisableJudgement", false);
            _disablePerfects = Category.CreateEntry("DisablePerfects", false);
            _disableGreats = Category.CreateEntry("DisableGreats", false);
            _disablePass = Category.CreateEntry("DisablePass", false);
            _makeJudgementSmaller = Category.CreateEntry("MakeJudgementSmaller", false,
                description: "DisableJudgement takes precedence.");
            _scalePercentage = Category.CreateEntry("JudgementScalePercentage", 75,
                description: "Range from 0-100%");
        }

        internal static void Init()
        {
            Category.LoadFromFile(false);
            
            // Verify scale is within range
            var currentScale = ScalePercentage;
            _scalePercentage.Value = Math.Clamp(ScalePercentage, 0, 100);
            if (currentScale == ScalePercentage) return;
            Melon<Main>.Logger.Warning("JudgementScalePercentage is out of bounds!");
        }
    }
}