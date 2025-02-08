using HarmonyLib;
using Il2CppAssets.Scripts.UI.GameMain;
using Il2CppAssets.Scripts.UI.Panels;
using Il2CppGameLogic;
using SelectiveEffects.Managers;
using UnityEngine;

namespace SelectiveEffects.Patches;

[HarmonyPatch]
internal static class StagePatch
{
    [HarmonyPatch(typeof(PnlBattle), nameof(PnlBattle.GameStart))]
    [HarmonyPostfix]
    internal static void GameStartPostfix()
    {
        if (!SettingsManager.Get<MainCategory>().IsEnabled)
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

    [HarmonyPatch(typeof(HitPointSubControl), nameof(HitPointSubControl.Awake))]
    [HarmonyPostfix]
    internal static void HitPostfix(HitPointSubControl __instance)
    {
        if (
            !SettingsManager.Get<MainCategory>().IsEnabled
            || !SettingsManager.Get<Stage>().DisableStageHitPoints
        )
        {
            return;
        }
        __instance.gameObject.SetActive(false);
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
