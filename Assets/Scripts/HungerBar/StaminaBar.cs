using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxStamina(int stamina)
    {
        //Sets the stamina's max value to this
        slider.maxValue = stamina;
        //And then it makes it full
        slider.value = stamina;
    }
    public void SetStamina(int stamina)
    {
        //Controls the slider's value
        slider.value = stamina;
    }
}
