using System;
using System.Collections;
using System.Collections.Generic;
using Global;
using TMPro;
using UnityEngine;

public class PlayerInformationUI1 : MonoBehaviour
{
    public TMP_Text PlayerDetailsText;
    public TMP_Text LevelText;
    public TMP_Text ExperienceRequiredText;
    // Start is called before the first frame update
    private void OnEnable()
    {
        PlayerDetailsText.text = AstriaManager.Instance.LocalPlayerInformation.PlayerName;
        LevelText.text = $"Level {AstriaManager.Instance.LocalPlayerInformation.PlayerLevel}";
        ExperienceRequiredText.text = $"Required XP: {AstriaManager.Instance.LocalPlayerInformation.CurrentExperience} / {AstriaManager.Instance.LocalPlayerInformation.ExperienceRequired}";
    }
}
