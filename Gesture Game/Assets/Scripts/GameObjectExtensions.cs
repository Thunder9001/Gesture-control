using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code to check whether game object is tagged from PitilT https://youtu.be/kVhuIHXoSIw
public static class GameObjectExtensionss
{
    public static bool HasTag(this GameObject gameObject, Tag t)
    {
        return gameObject.TryGetComponent<Tags>(out var tags) && tags.HasTag(t);
    }

    public static bool HasTag(this GameObject gameObject, string tagName)
    {
        return gameObject.TryGetComponent<Tags>(out var tags) && tags.HasTag(tagName);
    }
}
