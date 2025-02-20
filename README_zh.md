# SelectiveEffects

[English](README.md) | [中文](README_zh.md)

一个可以禁用战斗效果的Mod

* **请看 [安装](#安装)**.

## ❗来看看我的其他 [mods](https://github.com/Asgragrt/AsgraMDMods/blob/main/README.md)❗

## 功能特性

* 单独配置多个效果
* 热重载设置

### 热重载

无需重新启动游戏即可重新加载设置.

* 更改`SelectiveEffects.cfg`中的设置(参考[设置](#设置))并保存该文件.
* 设置只会在谱外重新加载.

## 设置

配置文件可以在`${Your muse dash folder}/UserData/SelectiveEffects.cfg`中找到


### Main

* `Enabled` 保存切换的最后状态 (就是Mod启动开关).
* `DisableAllEffects` 使用通用方法在战斗中禁用所有效果(如果你想单独修改下列项, 你需要将其改成false).

### Fever

* `DisableFever` 禁用 Fever 的背景和星星.
* `DisableBackground` 禁用 Fever 的背景 (保留星星和结束过度). **如果只有这个Fever选项被启用, 那它完全像是 _BALLCOCK_ mod**.
* `DisableStars` 禁用 Fever 的星星.
* `DisableTransition` 禁用结束过渡. **与 `DisableBackground` 搭配会更好看**.

### Judgement

* `DisableJudgement` 禁用判定 (包含early和late).
* `DisablePerfects` 禁用Perfect判定.
* `DisableGreats` 禁用Great判定.
* `DisablePass` 禁用Pass判定.
* `DisablePerfectPerfects` 禁用完美Perfect判定 (没有early和late).
* `MakeJudgementSmaller` 让判定变得更小.
* `JudgementScalePercentage` 原始判定百分比大小 (0% &rarr; 直接看不见, 100% &rarr; 原始大小的判定).

### Hit

* `DisableHitDisappearAnimation` 禁用敌人被击中时的动画，并使他们立即消失
* `DisableHitEffects` 禁用命中效果和粒子.
* `DisableGirlHitFx` 与 `DisableHitEffects` 一样 , 但是不会使某些敌人的out_fx消失.
* `DisableGirlHitParticlesOnly` 禁用命中时的星星粒子.
* `DisablePressFx` 禁用当你按下hold时的粒子

### MusicHearts

* `DisableMusicNotesFx` 禁用触摸音符出现的粒子和文本.
* `DisableHeartsFx` 禁用触摸爱心出现的粒子和文本.

### Misc

* `DisableBossFx` 禁用Boss在发射敌人时的一些效果.
* `DisableDustFx` 禁用角色掉落到地面时的灰尘效果.
* `DisableHurtFx` 禁用角色受伤时显示的文本.
* `DisableElfinFx` 禁用精灵效果.

### Stage

* `DisableStageBackground` 禁用舞台背景 (优先于 DisableStageExceptFloor).
* `DisableStageExceptFloor` 禁用除地板以外的舞台背景.
* `DisableStageHitPoints` 禁用判定点.

### GameScene

* `DisableGirl` 禁用角色的材质.
* `DisableElfin` 禁用精灵的材质.

> [!注意]
> 我们更倾向于使用 `DisableAllEffects` 选项, 而不是单独的选项 (这并不适用于**Fever**, **Stage**, 和 **GameScene** , 因为他们的处理方式不同).

## 安装

### 在此之前

* 确保你已经安装了 `MelonLoader 0.6.1` 或者更高的版本, 并在你的Muse Dash上面工作.

### 步骤

1. 从 [releases](https://github.com/MDMods/SelectiveEffects/releases/latest) 下载最新版.
2. 将下载好的 `SelectiveEffects.dll` 移动到 `${Your muse dash folder}/Mods`.
3. 运行游戏并修改配置文件中的设置.
