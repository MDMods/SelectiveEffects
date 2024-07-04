using MelonLoader;

namespace SelectiveEffects.Managers;

internal class FeverCategory : ICategory
{
    private readonly MelonPreferences_Category Category;
    private readonly MelonPreferences_Entry<bool> _disableBG;
    private readonly MelonPreferences_Entry<bool> _disableFever;
    private readonly MelonPreferences_Entry<bool> _disableStars;
    private readonly MelonPreferences_Entry<bool> _disableTransition;

    public FeverCategory()
    {
        Category = MelonPreferences.CreateCategory("Fever");
        Category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _disableFever = Category.CreateEntry("DisableFever", false);
        _disableBG = Category.CreateEntry("DisableBackground", false);
        _disableStars = Category.CreateEntry("DisableStars", false);
        _disableTransition = Category.CreateEntry("DisableTransition", false);
    }

    internal bool DisableBG => _disableBG.Value;
    internal bool DisableFever =>
        _disableFever.Value || (DisableBG && DisableStars && DisableTransition);
    internal bool DisableStars => _disableStars.Value;
    internal bool DisableTransition => _disableTransition.Value;

    void ICategory.Load()
    {
        Category.LoadFromFile(false);
    }

    void ICategory.Save()
    {
        Category.SaveToFile(false);
    }
}
