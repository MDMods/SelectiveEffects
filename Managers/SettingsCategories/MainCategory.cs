using MelonLoader;

namespace SelectiveEffects.Managers;

internal class MainCategory : ICategory
{
    private readonly MelonPreferences_Category Category;
    private readonly MelonPreferences_Entry<bool> _disableAllEffects;
    private readonly MelonPreferences_Entry<bool> _isEnabled;

    public MainCategory()
    {
        Category = MelonPreferences.CreateCategory("Main");
        Category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _isEnabled = Category.CreateEntry(
            "Enabled",
            true,
            description: "Enable or disable the mod!"
        );
        _disableAllEffects = Category.CreateEntry(
            "DisableAllEffects",
            true,
            description: "Takes precedence to the following options."
        );
    }

    internal bool DisableAllEffects => _disableAllEffects.Value;

    internal bool IsEnabled
    {
        get => _isEnabled.Value;
        set => _isEnabled.Value = value;
    }

    void ICategory.Load()
    {
        Category.LoadFromFile(false);
    }

    void ICategory.Save()
    {
        Category.SaveToFile(false);
    }
}
