using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code sourced from https://github.com/LandVr/SliceMeshes
// Permission to use and adapt given in https://youtu.be/iRW2CyQysdw
public class SliceListener : MonoBehaviour
{
    //Check when the slicer is in contact with a slicable object.
    public Slicer slicer;
    private void OnTriggerEnter(Collider other)
    {
        slicer.isTouched = true;
    }
}
