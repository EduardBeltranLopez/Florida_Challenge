using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trompo : MonoBehaviour
{

    public float playerJumpForce;
    public float potJumpForce;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * playerJumpForce);
        }

        if (other.gameObject.CompareTag("Pot"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * potJumpForce);
        }
    }
}
