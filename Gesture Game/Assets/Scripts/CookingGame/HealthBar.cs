using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code used originally from tutorial https://www.youtube.com/watch?v=BLfNP4Sc_iA
//Code repo found here https://github.com/Brackeys/Health-Bar
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void DecreaseHealth()
    {
        slider.value -= 1;
    }
}
