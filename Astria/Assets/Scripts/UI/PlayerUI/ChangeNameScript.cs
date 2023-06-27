using System;
using System.Collections;
using System.Collections.Generic;
using Global;
using TMPro;
using UnityEngine;

public class ChangeNameScript : MonoBehaviour
{
    public static event Action ChangedName;
    public TMP_InputField InputField;
    public GameObject MenuControllerObj;
    public void ChangeName()
    {
        AstriaManager.Instance.LocalPlayerInformation.PlayerName = InputField.text;
        Debug.Log("Changed Name");
        
        this.gameObject.GetComponent<MenuPage>().Close();
        ChangedName?.Invoke();
    }
}
