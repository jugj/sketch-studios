using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBar : MonoBehaviour
{

public int currentmana;
public int maxmana = 10;
    public Slider slider;

    //set max mana
    public void SetMaxMana(int maxmana){
        slider.maxValue = maxmana;
        slider.value = currentmana;
    }
    //set current mana
    public void SetCurrentMana(int currentmana){
slider.value = currentmana;
    }


}

