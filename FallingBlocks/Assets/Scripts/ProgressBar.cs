using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float MaxCounter;
    private float counter;

    public Slider slider;

    // Value between 0 and 1 (Percentage of health)
    private void setSliderValue(float value)
    {
        slider.value = value;
    }

    // set max counter for slider
    public void setMaxCounter(float MaxCounter)
    {
        this.MaxCounter = MaxCounter;
    }

    // Reduces counter and updates slider
    public void reduceAndUpdateCounter(float reduceBy)
    {
        this.counter = counter - reduceBy;
        this.getAndSetSliderValue();
    }

    // Gets percentage and sets the slider
    private void getAndSetSliderValue()
    {
        this.setSliderValue(this.counter / this.MaxCounter);
    }

}
