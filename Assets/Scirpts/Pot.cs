using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Rigidbody2D potRB;
    [SerializeField]GameObject dragon;

    private void Start()
    {
       potRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dragon"))
        {
            gameObject.SetActive(false);
        }

    }


   
}
