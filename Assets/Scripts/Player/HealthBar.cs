using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    public Slider slider;

    //set max mana
    public void SetMaxMana(int maxhealth){
        slider.maxValue = maxhealth;
        slider.value = currentHealth;
    }
    //set current mana
    public void SetCurrentHealth(int CurrentHealth){
        slider.value = CurrentHealth;
    }

}
