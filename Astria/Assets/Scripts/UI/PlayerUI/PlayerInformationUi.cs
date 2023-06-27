using System;
using System.Collections;
using System.Collections.Generic;
using Global;
using TMPro;
using UI.PlayerUI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformationUi : MonoBehaviour
{
    public static event Action UpdateUI;

    public TMP_Text PlayerDetailsText;
    public TMP_Text LevelText;
    public TMP_Text ExperienceRequiredText;
    public Image PlayerImage;

    public GameObject InteractUI;
    public void Start()
    {
        UpdateUI += OnUpdateUI;
        ChangeNameScript.ChangedName += ChangeNameScriptOnChangedName;
        InteractionNpc.EnableInteractUI += PlayerUiEventsOnEnableInteractUI;
        InteractionNpc.DisableInteractUI += PlayerUiEventsOnDisableInteractUI;
        UpdateUI?.Invoke();
    }

    private void ChangeNameScriptOnChangedName()
    {
        OnUpdateUI();
    }


    private void PlayerUiEventsOnDisableInteractUI()
    {
        InteractUI.SetActive(false);
    }

    private void PlayerUiEventsOnEnableInteractUI()
    {
        InteractUI.SetActive(true);
    }

    private void OnUpdateUI()
    {
        // Set Player Name
        PlayerDetailsText.text = AstriaManager.Instance.LocalPlayerInformation.PlayerName;
        LevelText.text = $"Level {AstriaManager.Instance.LocalPlayerInformation.PlayerLevel}";
        ExperienceRequiredText.text = $"Required XP: {AstriaManager.Instance.LocalPlayerInformation.CurrentExperience} / {AstriaManager.Instance.LocalPlayerInformation.ExperienceRequired}";
    }
}
