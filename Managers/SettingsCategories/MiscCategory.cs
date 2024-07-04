using MelonLoader;

namespace SelectiveEffects.Managers;

internal class MiscCategory : ICategory
{
    private readonly MelonPreferences_Category Category;
    private readonly MelonPreferences_Entry<bool> _disableBossFx;
    private readonly MelonPreferences_Entry<bool> _disableDustFx;
    private readonly MelonPreferences_Entry<bool> _disableElfinFx;
    private readonly MelonPreferences_Entry<bool> _disableHurtFx;

    public MiscCategory()
    {
        Category = MelonPreferences.CreateCategory("Misc");
        Category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _disableBossFx = Category.CreateEntry("DisableBossFx", false);
        _disableElfinFx = Category.CreateEntry("DisableElfinFx", false);
        _disableDustFx = Category.CreateEntry("DisableDustFx", false);
        _disableHurtFx = Category.CreateEntry(
            "DisableHurtFx",
            false,
            description: "Disable hp loss text."
        );
    }

    internal bool DisableBossFx => _disableBossFx.Value;
    internal bool DisableDustFx => _disableDustFx.Value;
    internal bool DisableElfinFx => _disableElfinFx.Value;
    internal bool DisableHurtFx => _disableHurtFx.Value;

    void ICategory.Load()
    {
        Category.LoadFromFile(false);
    }

    void ICategory.Save()
    {
        Category.SaveToFile(false);
    }
}
