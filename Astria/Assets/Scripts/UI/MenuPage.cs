using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPage : MonoBehaviour
{

    public string Name;
    public bool isOpen = false;
    public bool isPopup;

    public void Open()
    {
        isOpen = true;
        
        this.gameObject.SetActive(isOpen);
        Debug.Log("Opened Page: " + name);
    }

    public void Close()
    {
        isOpen = false;
        
        this.gameObject.SetActive(isOpen);
        Debug.Log("Closed Page: " + name);
    }
}