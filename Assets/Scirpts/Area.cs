using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDisparo : MonoBehaviour
{
    private Animator anima;

    [Header("General References")]
    public Transform voz;
    public Transform controladorDisparo;
    [SerializeField] Vector2 direction;

    [Header("Shoot Configuration")]

    [SerializeField] float tiempoDeVida;
    public GameObject balaEnemigo;
    public float tiempoEntreDisparos;
    public float tiempoUltimoDisparo;
    public float tiempoEsperaDisparo;

    void Start()
    {
        anima = GetComponent<Animator>();

    }
    private void Update()
    {

        
    }
    private void Disparar()
    {
        GameObject Fire = Instantiate(balaEnemigo, controladorDisparo.position, controladorDisparo.rotation);
        Bala bulletScript = Fire.GetComponent<Bala>();
        bulletScript.bulletDirection = direction;

    }

    private void OnTriggerStay2D(Collider2D voz)
    {
        if (voz.gameObject.CompareTag("Player"))
        {

            direction = (voz.gameObject.transform.position - transform.position).normalized;

            if (Time.time > tiempoEntreDisparos + tiempoUltimoDisparo)
            {
                tiempoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEntreDisparos);
            }
        }
    }

    

}
