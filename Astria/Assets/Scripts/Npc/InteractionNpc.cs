using System;
using System.Collections;
using System.Collections.Generic;
using Global;
using UnityEngine;

public class InteractionNpc : MonoBehaviour
{
    public static event Action EnableInteractUI;
    public static event Action DisableInteractUI;

    public GameObject InteractionPrefab;
    public GameObject UiContainerPanel;
    public string PageName;
    private bool _currentlyOpen = false;
    public bool SceneChange = true;
    public string SceneName;
    public bool GiveRewards;
    public int XPReward = 200;
    public void OpenInteractionNPCMenu()
    {

        var t = InteractionPrefab.GetComponent<MenuController>();
        t.OpenPage(PageName);
    }
    
    public void ChangeScene(string sceneName)
    {

        if (GiveRewards)
        {
            AstriaManager.Instance.LocalPlayerInformation.CurrentExperience += XPReward;
        }
        
        AstriaManager.Instance.OpenScene(sceneName);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnableInteractUI?.Invoke();
        }
    }
     
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            DisableInteractUI?.Invoke();
        }
    }
}
