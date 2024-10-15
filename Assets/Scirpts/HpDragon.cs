using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDragon : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;



    // Start is called before the first frame update
    public void SetHealth(float healt, float maxHealth)
    {
        slider.gameObject.SetActive(healt < maxHealth);
        slider.value = healt;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
}
