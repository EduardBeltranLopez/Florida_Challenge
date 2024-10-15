using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillDragon : MonoBehaviour
{
    [Header("Stats Basicos")]
    [SerializeField] float dragonHp = 5;
    public float currentHp;
    [SerializeField] GameObject fullEnemy;
    [SerializeField] GameObject winPanel;

    [Header("Barra")]
    public Slider slider;
    public Color low;
    public Color high;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = dragonHp;
    }
    // Update is called once per frame
    void Update()
    {
        SetHealth();
        Die();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            currentHp --;

        }
    }

    void Die()
    {
        if (currentHp <= 0)
        {
            fullEnemy.SetActive(false);
            winPanel.SetActive(true);
        }
    }

    public void SetHealth()
    {
        slider.gameObject.SetActive(currentHp < dragonHp);
        slider.value = currentHp;
        slider.maxValue = dragonHp;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
}
