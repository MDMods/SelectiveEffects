using MelonLoader;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    //--------------------------------------------------------------------+
    // Judgement Category
    //--------------------------------------------------------------------+
    internal static bool DisableJudgement => JudgementCategory._disableJudgement.Value
                                             || (DisablePerfects && DisableGreats && DisablePass);

    internal static bool MakeJudgementSmaller => JudgementCategory._makeJudgementSmaller.Value;
    internal static bool DisablePerfects => JudgementCategory._disablePerfects.Value;
    internal static bool DisableGreats => JudgementCategory._disableGreats.Value;
    internal static bool DisablePass => JudgementCategory._disablePass.Value;
    
    private static class JudgementCategory
    {
        internal static MelonPreferences_Entry<bool> _disableJudgement;
        internal static MelonPreferences_Entry<bool> _makeJudgementSmaller;
        internal static MelonPreferences_Entry<bool> _disablePerfects;
        internal static MelonPreferences_Entry<bool> _disableGreats;
        internal static MelonPreferences_Entry<bool> _disablePass;

        internal static void Init()
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
}