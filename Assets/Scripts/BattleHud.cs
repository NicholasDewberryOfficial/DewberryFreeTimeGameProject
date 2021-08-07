using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

   public TextMeshProUGUI Name;
   public Slider hpSlider;
   public Slider HeatSlider;



    // Start is called before the first frame update
    public void SetHud(Unit unit)
    {
        Name.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        HeatSlider.value = unit.HeatLevel;

    }

    public void SetHP(int hp){
        hpSlider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
