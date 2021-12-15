using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    // Value between 0 and 1 (Percentage of health)
    public void setSliderValue(float value)
    {
        slider.value = value;
    }
}
