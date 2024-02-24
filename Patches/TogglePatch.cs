using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.GeneralLocalization;
using Il2CppAssets.Scripts.UI.Panels;
using SelectiveEffects.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Nice = Il2CppAssets.Scripts.PeroTools.Nice;

namespace SelectiveEffects.Patches
{
    [HarmonyPatch(typeof(PnlMenu), nameof(PnlMenu.Awake))]
    internal class TogglePatch
    {
        internal static GameObject EffectsToggle;
        public static void Postfix(PnlMenu __instance)
        {
            if (EffectsToggle) return;

            EffectsToggle = UnityEngine.Object.Instantiate(
                GameObject.Find("Forward").transform.Find("PnlVolume").Find("LogoSetting").Find("Toggles").Find("TglOn").gameObject,
                __instance.transform
                );


            Toggle toggleComp = EffectsToggle.GetComponent<Toggle>();
            toggleComp.onValueChanged.AddListener((UnityAction<bool>)
                ((bool val) => { SettingsManager.Enabled = val; })
                );
            toggleComp.group = null;
            toggleComp.SetIsOnWithoutNotify(SettingsManager.Enabled);

            EffectsToggle.name = "EffectsToggleObject";

            Text txt = EffectsToggle.transform.Find("Txt").GetComponent<Text>();
            txt.text = "Disable Effects";
            txt.fontSize = 40;
            txt.color = new Color(1, 1, 1, 76 / 255f);
            RectTransform rect = txt.transform.Cast<RectTransform>();
            Vector2 vect = rect.offsetMax;
            rect.offsetMax = new Vector2(txt.text.Length * 25, vect.y);


            Image checkBox = EffectsToggle.transform.Find("Background").GetComponent<Image>();
            checkBox.color = new(60 / 255f, 40 / 255f, 111 / 255f);

            Image checkMark = EffectsToggle.transform.Find("Background").GetChild(0).GetComponent<Image>();
            checkMark.color = new(103 / 255f, 93 / 255f, 130 / 255f);


            UnityEngine.Object.Destroy(txt.GetComponent<Localization>());
            UnityEngine.Object.Destroy(EffectsToggle.GetComponent<Nice.Events.OnToggle>());
            UnityEngine.Object.Destroy(EffectsToggle.GetComponent<Nice.Events.OnToggleOn>());
            UnityEngine.Object.Destroy(EffectsToggle.GetComponent<Nice.Events.OnActivate>());
            UnityEngine.Object.Destroy(EffectsToggle.GetComponent<Nice.Variables.VariableBehaviour>());

            EffectsToggle.transform.position = new Vector3(-6.8f, -4.95f, 100f);
            EffectsToggle.transform.SetParent(__instance.transform.Find("Panels").Find("PnlOption").Find("TxtVersion"));
        }
    }
}
