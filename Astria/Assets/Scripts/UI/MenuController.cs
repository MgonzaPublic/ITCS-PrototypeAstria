using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public List<MenuPage> Pages;

    public void OpenPage(string NameOfPage)
    {
        if(Pages.Count <= 0)
            return;

        MenuPage OpenPage = Pages.Find(x => x.Name == NameOfPage);
        
        if(!OpenPage.isPopup) // Allows Pages to continue being open while popups close.
        {
            Pages.ForEach(delegate(MenuPage page)
            {
                page.Close();
            });
        }
        
        OpenPage.Open();
        
    }

    public void ClosePage(string pageName)
    {
        if(Pages.Count <= 0)
            return;

        MenuPage OpenPage = Pages.Find(x => x.Name == pageName);

        if (!OpenPage.isOpen)
        {
            return;
        }
        
        OpenPage.Close();
    }

    public void ClosePopup(MenuPage popup)
    {
        if(!popup.isPopup)
            return;
        
        popup.Close();
    }
}