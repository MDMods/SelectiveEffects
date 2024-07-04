using MelonLoader;

namespace SelectiveEffects.Managers;

internal class StageCategory : Category
{
    private readonly MelonPreferences_Entry<bool> _disableElfin;
    private readonly MelonPreferences_Entry<bool> _disableGirl;
    private readonly MelonPreferences_Entry<bool> _disableStageBackground;
    private readonly MelonPreferences_Entry<bool> _disableStageExceptFloor;

    public StageCategory()
        : base("Stage")
    {
        _disableStageBackground = _category.CreateEntry(
            "DisableStageBackground",
            false,
            description: "Disable the stage background (Takes precedence over DisableStageExceptFloor)."
        );

        _disableStageExceptFloor = _category.CreateEntry(
            "DisableStageExceptFloor",
            false,
            description: "Disable the stage background except the floor."
        );
    }

    internal bool DisableElfin => _disableElfin.Value;
    internal bool DisableGirl => _disableGirl.Value;
    internal bool DisableStage => DisableStageBackGround || DisableStageExceptFloor;
    internal bool DisableStageBackGround => _disableStageBackground.Value;
    internal bool DisableStageExceptFloor => _disableStageExceptFloor.Value;
}
