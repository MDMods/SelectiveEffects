# SelectiveEffects

Mod that allows disabling battle effects.

* **Please take a look at [installation](#installation)**.

## ❗Check out my other [mods](https://github.com/Asgragrt/AsgraMDMods/blob/main/README.md)❗

## Features

* Individual config options for several effects.
* Enable/disable toggle at the menu.
* Hot reload settings.

### Hot Reload

Reload your settings without having to restart the game.

* Change the settings inside `SelectiveEffects.cfg` (see [Settings](#settings)) and the save the file.
* The settings will reload only outside the charts.

## Settings

The config file can be found at `${Your muse dash folder}/UserData/SelectiveEffects.cfg`

### Main

* `Enabled` stores the last status of the toggle.
* `DisableAllEffects` uses a general method to disable all effects in battle.

### Fever

* `DisableFever` disables fever's background and stars.
* `DisableBackground` disables the fever background (keeping the stars and the ending transition). **If only this fever
  option is enabled it behaves exactly like _BALLCOCK_ mod**.
* `DisableStars` disables the fever stars.
* `DisableTransition` disables the ending transition. **Looks better with `DisableBackground`**.

### Judgement

* `DisableJudgement` disables the judgements (including early/late).
* `DisablePerfects` disables the perfect judgement.
* `DisableGreats` disables the great judgement.
* `DisablePass` disables the pass judgement.
* `MakeJudgementSmaller` makes judgements smaller.
* `JudgementScalePercentage` original judgement size percentage (0% &rarr; invisible judgements, 100% &rarr; original
  size judgements).

### Hit

* `DisableHitDisappearAnimation` disables the enemies animation when they have been hit and makes them disappear
  immediately.
* `DisableHitEffects` disables hit effects and particles.
* `DisableGirlHitFx` the same as `DisableHitEffects` but doesn't disappear the out_fx of some enemies.
* `DisableGirlHitParticlesOnly` disables the hit star particles.
* `DisablePressFx` disables some particles when pressing the holds.

### MusicHearts

* `DisableMusicNotesFx` disables the particles and text that appear when you touch a music note.
* `DisableHeartsFx` disables the particles and text that appear when you touch a heart.

### Misc

* `DisableBossFx` disables some effects the boss has when deploying enemies.
* `DisableDustFx` disables the dust effect when the character falls to the ground.
* `DisableHurtFx` disables the text that appear when the character is hurt.
* `DisableElfinFx` disables elfin effects.

It is preferred to use the `DisableAllEfects` option instead of the individual options (this doesn't apply to the Fever
effects since they are handled in a different way).

## In-game screenshots

### Menu Toggle

![MenuToggle](Media/MenuToggle.jpg)

## Installation

### Prerequisites

* Make sure you have `MelonLoader 0.6.1` or higher installed and working on your Muse Dash.
* [MuseDashMirror 3.1.3](https://github.com/MDMods/MuseDashMirror/releases/latest) or higher

### Steps

1. Download the latest release from [releases](https://github.com/MDMods/SelectiveEffects/releases/latest).
2. Move `SelectiveEffects.dll` to `${Your muse dash folder}/Mods`.
3. Run the game and modify the settings on the config file.
