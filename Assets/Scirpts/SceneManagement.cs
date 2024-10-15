using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManag : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    public int[] scenas = new int[2] {0, 1} ;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void Jugar()
    {
        SceneManager.LoadScene(scenas[1]) ;
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(scenas[0]);
    }
}

