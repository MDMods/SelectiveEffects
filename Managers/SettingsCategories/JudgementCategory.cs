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
        internal static MelonPreferences_Entry<bool> _disableJudgement;
        internal static MelonPreferences_Entry<bool> _disablePerfects;
        internal static MelonPreferences_Entry<bool> _disableGreats;
        internal static MelonPreferences_Entry<bool> _disablePass;
        internal static MelonPreferences_Entry<bool> _makeJudgementSmaller;
        internal static MelonPreferences_Entry<int> _scalePercentage;

        internal static void Init()
        {
            var judgementCategory = MelonPreferences.CreateCategory("Judgement");
            judgementCategory.SetFilePath(SettingsPath, true, false);

            _disableJudgement = judgementCategory.CreateEntry("DisableJudgement", false);
            _disablePerfects = judgementCategory.CreateEntry("DisablePerfects", false);
            _disableGreats = judgementCategory.CreateEntry("DisableGreats", false);
            _disablePass = judgementCategory.CreateEntry("DisablePass", false);
            _makeJudgementSmaller = judgementCategory.CreateEntry("MakeJudgementSmaller", false,
                description: "DisableJudgement takes precedence.");
            _scalePercentage = judgementCategory.CreateEntry("JudgementScalePercentage", 75,
                description: "Range from 0-100%");
            
            // Verify scale is within range
            var currentScale = ScalePercentage;
            _scalePercentage.Value = Math.Clamp(ScalePercentage, 0, 100);
            if (currentScale == ScalePercentage) return;
            Melon<Main>.Logger.Warning("JudgementScalePercentage is out of bounds!");
        }
    }
}