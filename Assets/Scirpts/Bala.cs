using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public float velocidadBala;
    public Vector2 bulletDirection;
    [SerializeField] float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(AutoDestroy), destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * velocidadBala * bulletDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Pot"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false); 
        }
    }

    void AutoDestroy()
    {
        gameObject.SetActive(false);
    }

}
