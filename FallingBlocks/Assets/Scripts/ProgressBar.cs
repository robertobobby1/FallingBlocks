using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float MaxCounter;
    private float counter;
    private bool isReverse;

    public Slider slider;

    // Value between 0 and 1 (Percentage of health)
    private void setSliderValue(float value)
    {
        slider.value = value;
    }

    public void setReverseProgressBar(bool reversable)
    {
        isReverse = reversable;
    }

    // set max counter for slider
    public void setMaxCounter(float MaxCounter_)
    {
        MaxCounter = MaxCounter_;
        counter = MaxCounter;
    }

    // Reduces counter and updates slider
    public void reduceAndUpdateCounter(float reduceBy)
    {
        counter = counter - reduceBy;
        getAndSetSliderValue();
    }

    // Gets percentage and sets the slider
    private void getAndSetSliderValue()
    {
        float sliderValue = counter / MaxCounter;
        if (isReverse)
            sliderValue = 1 - sliderValue; 

        this.setSliderValue(sliderValue);
    }

}
