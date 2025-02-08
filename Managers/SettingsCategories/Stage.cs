using MelonLoader;

namespace SelectiveEffects.Managers;

internal class Stage : Category
{
    private readonly MelonPreferences_Entry<bool> _disableStageBackground;

    private readonly MelonPreferences_Entry<bool> _disableStageExceptFloor;

    private readonly MelonPreferences_Entry<bool> _disableStageHitPoints;

    public Stage()
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

        _disableStageHitPoints = _category.CreateEntry(
            "DisableStageHitPoints",
            false,
            description: "Disable the hit spinning circles."
        );
    }

    internal bool DisableStage => DisableStageBackGround || DisableStageExceptFloor;
    internal bool DisableStageBackGround => _disableStageBackground.Value;
    internal bool DisableStageExceptFloor => _disableStageExceptFloor.Value;
    internal bool DisableStageHitPoints => _disableStageHitPoints.Value;
}
