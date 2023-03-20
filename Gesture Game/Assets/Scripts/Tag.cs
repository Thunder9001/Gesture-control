using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Code to check whether game object is tagged from PitilT https://youtu.be/kVhuIHXoSIw
[CreateAssetMenu(fileName = "New tag", menuName = "Tags/New Tag")]
public class Tag : ScriptableObject
{
    public string Name => name;
}
