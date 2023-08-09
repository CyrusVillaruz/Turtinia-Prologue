using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStamina(float maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
    }

    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }
}
