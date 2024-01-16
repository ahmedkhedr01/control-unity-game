using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossArmorBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    public Color fullHealthColor = Color.blue;


    public void UpdateBossArmorBar(int health, int maxHealth)
    {
        float healthPercentage = ((float)health / (float)maxHealth);
        slider.value = healthPercentage;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Color.black, fullHealthColor, healthPercentage * 4);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
