using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRb;
    private Animator anim;
    private float horizontalInput;

    [Header("Movement & Jump Stats")]
    public float speed;
    private bool isFacingRight = true;

    [Header("Respawn")]
    [SerializeField] float respa;

    [Header("Dash")]
    [SerializeField] private float dashTime;
    [SerializeField] private float dashForce;
    float gravedadInicial;
    bool puedeHacerDash = true;
    bool sePuedeMover = false;

    [Header("Paneles")]
    public GameObject losePanel;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gravedadInicial = playerRb.gravityScale;
    }

    void Update()
    {
        Movement();
        if (sePuedeMover)
        {
            Dasheo();
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);

        if (horizontalInput != 0f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (horizontalInput > 0)
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
        if (horizontalInput < 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }

    }

    void Flip()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bulet"))
        {
            losePanel.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Down"))
        {
 
            anim.SetBool("isCrouching", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Down"))
        {
            anim.SetBool("isCrouching", false);
        }
    }

    void Dasheo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedeHacerDash)
        {
            StartCoroutine(Empuje());
        }
    }

    private IEnumerator Empuje()
    {
        sePuedeMover = false;
        puedeHacerDash = false;
        playerRb.gravityScale = 0;
        playerRb.velocity = new Vector2(dashForce, 0);

        yield return new WaitForSeconds(dashTime);

        sePuedeMover = true;
        puedeHacerDash = true;
        playerRb.gravityScale = gravedadInicial;
    }

    
}