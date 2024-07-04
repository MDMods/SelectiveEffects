using MelonLoader;
using SelectiveEffects.Managers;

namespace SelectiveEffects;

internal class Category : ICategory
{
    internal Category(string name)
    {
        _category = MelonPreferences.CreateCategory(name);
        _category.SetFilePath(SettingsManager.SettingsPath, false, false);
    }

    protected MelonPreferences_Category _category { get; init; }

    public virtual void Load()
    {
        _category.LoadFromFile(false);
    }

    public void Save()
    {
        _category.SaveToFile(false);
    }
}
