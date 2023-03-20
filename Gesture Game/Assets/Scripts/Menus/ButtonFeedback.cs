using Leap.Unity;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFeedback : MonoBehaviour
{
    [Header("Interaction Behaviour Colors")]
    public Color defaultColor = Color.Lerp(Color.black, Color.white, 0.1F);
    public Color hoverColor = Color.Lerp(Color.black, Color.white, 0.7F);

    [Header("InteractionButton Colors")]
    [Tooltip("This color only applies if the object is an InteractionButton or InteractionSlider.")]
    public Color pressedColor = Color.white;

    public void HoverBeginColour()
    {
        Renderer cube = transform.Find("Button Cube").GetComponent<Renderer>();
        cube.material.color = hoverColor;
    }
    public void DefaultColour()
    {
        Renderer cube = transform.Find("Button Cube").GetComponent<Renderer>();
        cube.material.color = defaultColor;
    }
    public void PressColour()
    {
        Renderer cube = transform.Find("Button Cube").GetComponent<Renderer>();
        cube.material.color = pressedColor;
    }
}
