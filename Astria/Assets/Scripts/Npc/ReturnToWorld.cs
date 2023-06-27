using System.Collections;
using System.Collections.Generic;
using Global;
using UnityEngine;

public class ReturnToWorld : MonoBehaviour
{
    public void OpenInteractionNPCMenu()
    {

        AstriaManager.Instance.OpenScene("AstriaWorld");
    }
}
