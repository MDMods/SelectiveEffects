using HarmonyLib;
using Il2CppAssets.Scripts.UI.Panels;
using Il2CppGameLogic;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches;

[HarmonyPatch(typeof(PnlBattle), nameof(PnlBattle.GameStart))]
internal static class StagePatch
{
    internal static void Postfix()
    {
        if (!SettingsManager.Get<Managers.MainCategory>().IsEnabled)
            return;

        var stageCategory = SettingsManager.Get<Stage>();
        if (!stageCategory.DisableStage)
            return;

        var musicScene = GameGlobal.gGameMusicScene;
        List<GameObject> scenes = [];
        if (musicScene?.scenes != null)
        {
            foreach (var scene in musicScene.scenes)
            {
                scenes.Add(scene);
            }
        }
        else
        {
            scenes.Add(musicScene.scene);
        }

        if (stageCategory.DisableStageBackGround)
        {
            foreach (var scene in scenes)
            {
                var activeStatus = scene.active;

                scene.SetActiveRecursively(false);

                scene.active = activeStatus;
            }
            return;
        }

        if (stageCategory.DisableStageExceptFloor)
        {
            foreach (var scene in scenes)
            {
                var activeStatus = scene.active;

                RecursiveFloor(scene);

                scene.active = activeStatus;
            }

            return;
        }
    }

    private static bool RecursiveFloor(GameObject parent) => RecursiveFloor(parent.transform);

    private static bool RecursiveFloor(Transform parent)
    {
        var name = parent.name;

        if (name.InvariantContains("floor"))
        {
            return true;
        }

        var childCount = parent.childCount;
        if (childCount > 0)
        {
            var isFloorParent = false;
            List<Transform> children = [];
            for (var i = 0; i < childCount; i++)
            {
                isFloorParent |= RecursiveFloor(parent.GetChild(i));
            }

            parent.gameObject.active = isFloorParent;
            return isFloorParent;
        }

        var isFloor = name.InvariantContains("Floor") || name.InvariantContains("Road");

        parent.gameObject.active = isFloor;
        return isFloor;
    }
}
