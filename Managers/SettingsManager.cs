using MelonLoader.Utils;
using SelectiveEffects.Properties;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    internal const string SettingsPath = "UserData/" + SettingsFileName;

    private const string SettingsFileName = $"{MelonBuildInfo.ModName}.cfg";

    private static readonly FileSystemWatcher Watcher = new(MelonEnvironment.UserDataDirectory);

    private static readonly List<ICategory> _categories = [];

    static SettingsManager()
    {
        Init();

        Load();

        // Create file at runtime if it doesn't exist or update the settings file with all the categories
        Save();

        Watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;

        Watcher.Filter = SettingsFileName;

        Watcher.Changed += Main.QueueReload;
    }

    //private static Dictionary<Type, ISettings> Settings { get; } = [];

    internal static void DisableWatcherEvents()
    {
        Watcher.EnableRaisingEvents = false;
    }

    internal static void EnableWatcherEvents()
    {
        Watcher.EnableRaisingEvents = true;
    }

    internal static T Get<T>()
        where T : ICategory, new()
    {
        if (Settings<T>.Instance == null)
        {
            throw new InvalidDataException($"Setting {typeof(T)} has not been initialized.");
        }

        return Settings<T>.Instance;
    }

    internal static void Load()
    {
        _categories.ForEach(c => c.Load());
    }

    internal static void Save()
    {
        _categories.ForEach(c => c.Save());
    }

    private static void Init()
    {
        Init<MainCategory>();
        Init<Fever>();
        Init<Judgement>();
        Init<Hit>();
        Init<MusicHearts>();
        Init<Misc>();
        Init<Stage>();
        Init<GameScene>();
        Init<Interface>();
    }

    private static void Init<T>()
        where T : ICategory, new()
    {
        if (Settings<T>.Instance != null)
            return;

        Settings<T>.Instance = new();

        _categories.Add(Get<T>());
    }

    private static class Settings<T>
        where T : ICategory
    {
        internal static T Instance { get; set; }
    }
}
