using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintActivation : MonoBehaviour
{
    public void PrintActivatedMsg()
    {
        Debug.Log("Activated");
    }

    public void PrintDeactivatedMsg()
    {
        Debug.Log("Deactivated");
    }
}
