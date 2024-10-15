using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField]private Transform[] puntos;
    [SerializeField] private GameObject[] pots;
    [SerializeField] private float tiempoEntrePots;
    private float tiempoSiguientePot;

    private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    void Update()
    {
        tiempoSiguientePot += Time.deltaTime;

        if (tiempoSiguientePot >= tiempoEntrePots )
        {
            tiempoSiguientePot = 0;
            CrearEnemigo();
        }
    }

    void CrearEnemigo()
    {
        int numeroPot = Random.Range(0, pots.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(pots[numeroPot], posicionAleatoria, Quaternion.identity);
    }

}
