# SelectiveEffects
Mod that allows disabling battle effects.

## Features
* Individual config options for several effects.
* Enable/disable toggle at the menu.

## Settings
The config file can be found at `${Your muse dash folder}/UserData/SelectiveEffects.cfg`
### Main
* `Enabled` stores the last status of the toggle.
* `DisableAllEfects` uses a general method to disable all effects in battle.
### Fever
* `DisableFever` disables fever's background and stars.
* `DisableBackground` disables the fever background (keeping the stars and the ending transition). **If only this fever option is enabled it behaves exactly like _BALLCOCK_ mod**.
* `DisableStars` disables the fever stars.
* `DisableTransition` disables the ending transition. **Looks better with `DisableBackground`**.
### Judgement
* `DisableJudgement` disables the judgements (including early/late).
* `MakeJudgementSmaller` if the judgements are available, it makes them ~25% smaller.
* `DisablePerfects` disables the perfect judgement.
* `DisableGreats` disables the great judgement.
* `DisablePass` disables the pass judgement.
### Hit
* `DisableHitDissapearAnimation` disables the enemies animation when they have been hit and makes them disappear inmmeadiatly.
* `DisableHitEffects` disables the hit effects and particles.
* `DisableGirlHitFx` the same as `DisableHitEffects` but doesn't disappear the out_fx of some enemies.
* `DisablePressFx` disables some particles when pressing the holds.
### MusicHearts
* `DisableMusicNotesFx` disables the particles and text that appear when you touch a music note.
* `DisableHeartsFx` disables the particles and text that appear when you touch a heart.
### Misc
* `DisableBossFx` disables some effects the boss has when deploying enemies.
* `DisableDustFx` disables the dust effect when the character falls to the ground.
* `DisableHurtFx` disables the text that appear when the character is hurt.
* `DisableElfinFx` disables elfin effects.

It is prefered to use the `DisableAllEfects` option instead of the individual options (this doesn't apply to the Fever effects since they are handled in a different way).

## In-game screenshots
### Menu Toggle
![MenuToggle](Media/MenuToggle.jpg)

##  ❗Check out my other [mods](https://github.com/Asgragrt#musedash-modding)❗
