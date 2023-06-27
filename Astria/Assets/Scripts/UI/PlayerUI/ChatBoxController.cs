using System.Collections;
using System.Collections.Generic;
using Global;
using TMPro;
using UnityEngine;

public class ChatBoxController : MonoBehaviour
{
    public GameObject TextPrefab;
    public GameObject TextboxPanel;
    public GameObject TextInputObj;
   
    
    public void AddChatMessage()
    {
        GameObject obj = Instantiate(TextPrefab);
        var inputComponent = TextInputObj.GetComponent<TMP_InputField>();
        obj.GetComponent<TMP_Text>().text = $"{AstriaManager.Instance.LocalPlayerInformation.PlayerName}: {inputComponent.text}";
        inputComponent.text = string.Empty;
        obj.transform.SetParent(TextboxPanel.transform, false);
        Debug.Log("Added Chat Message");
    }

    public void ChatboxInputSelected(){
        AstriaManager.Instance.SetWalkable(false);
    }

    public void ChatboxInputDeselected(){
        AstriaManager.Instance.SetWalkable(true);
    }
}
