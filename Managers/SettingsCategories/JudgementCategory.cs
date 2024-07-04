using MelonLoader;

namespace SelectiveEffects.Managers;

internal class JudgementCategory : ICategory
{
    private readonly MelonPreferences_Category Category;
    private readonly MelonPreferences_Entry<bool> _disableGreats;
    private readonly MelonPreferences_Entry<bool> _disableJudgement;
    private readonly MelonPreferences_Entry<bool> _disablePass;
    private readonly MelonPreferences_Entry<bool> _disablePerfectPerfects;
    private readonly MelonPreferences_Entry<bool> _disablePerfects;
    private readonly MelonPreferences_Entry<bool> _makeJudgementSmaller;
    private readonly MelonPreferences_Entry<int> _scalePercentage;

    public JudgementCategory()
    {
        Category = MelonPreferences.CreateCategory("Judgement");
        Category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _disableJudgement = Category.CreateEntry("DisableJudgement", false);
        _disablePerfects = Category.CreateEntry("DisablePerfects", false);
        _disableGreats = Category.CreateEntry("DisableGreats", false);
        _disablePass = Category.CreateEntry("DisablePass", false);
        _disablePerfectPerfects = Category.CreateEntry("DisablePerfectPerfects", false);
        _makeJudgementSmaller = Category.CreateEntry(
            "MakeJudgementSmaller",
            false,
            description: "DisableJudgement takes precedence."
        );
        _scalePercentage = Category.CreateEntry(
            "JudgementScalePercentage",
            75,
            description: "Range from 0-100%"
        );
    }

    internal bool DisableGreats => _disableGreats.Value;
    internal bool DisableJudgement =>
        _disableJudgement.Value
        || (DisablePerfects && DisableGreats && DisablePass)
        || ScalePercentage == 0;
    internal bool DisablePass => _disablePass.Value;
    internal bool DisablePerfectPerfects => _disablePerfectPerfects.Value;
    internal bool DisablePerfects => _disablePerfects.Value;
    internal bool MakeJudgementSmaller => _makeJudgementSmaller.Value;
    internal int ScalePercentage => _scalePercentage.Value;

    void ICategory.Load()
    {
        Category.LoadFromFile(false);

        // Verify scale is within range
        var currentScale = ScalePercentage;
        _scalePercentage.Value = Math.Clamp(ScalePercentage, 0, 100);
        if (currentScale == ScalePercentage)
            return;
        Melon<Main>.Logger.Warning("JudgementScalePercentage is out of bounds!");
    }
}
