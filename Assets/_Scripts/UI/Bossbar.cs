using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bossbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxBossHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetBossHealth(float health)
    {
        slider.value = health;
    }
}
