using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] static bool npcdegme = false;
    private bool kapýtemas = false;


    public GameObject dialogmanager;
    public GameManager GameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (npcdegme == true && Input.GetKey(KeyCode.E))
        {
            GameManager.dialog.SetActive(true);
            GameManager.dialog2.SetActive(true);
        }
        if (kapýtemas)
        {

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                GameManager.tpmenu.SetActive(true);

            }
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                GameManager.tpmenu.SetActive(false);
            }
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("npc"))
        {
            npcdegme = true;
        }
        else
        {
            npcdegme = false;
        }
        if (collision.CompareTag("masa") && Input.GetKey(KeyCode.E))
        {
            GameManager.kamera1.enabled = false;
            GameManager.kamera4.enabled = true;
            gameObject.SetActive(false);
            Destroy(GameManager.ýpucu);
            GameManager.ýpucu2.SetActive(true);
            
        }

        if (collision.CompareTag("dosya"))
        {
            GameManager.dosyatake = true;
            Destroy(GameManager.dosya);
        }
        if (collision.CompareTag("ipucu2"))
        {
            GameManager.ýpucu2tab.SetActive(true);
        }
        if(collision.CompareTag("cam")&& Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("katilev");
        }
            


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kapý"))
        {

            kapýtemas = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kapý"))
        {
            kapýtemas = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("npc"))
        {
            npcdegme = false;
            GameManager.dialog.SetActive(false);
        }
        if (collision.CompareTag("kapý1"))
        {
            kapý.kapical = false;

        }
        if (collision.CompareTag("kapý2"))
        {
            kapý.kapical = false;

        }
        if (collision.CompareTag("kapý3"))
        {
            kapý.kapical = false;

        }
        if (collision.CompareTag("ipucu2"))
        {
            GameManager.ýpucu2tab.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("kapý1"))
        {
            kapý.kapical = true; kapý.kapilarindex = 0;

            
        }
        if (collision.CompareTag("kapý2"))
        {
                kapý.kapical = true; kapý.kapilarindex = 1;
        }
        if (collision.CompareTag("kapý3"))
        {
            kapý.kapical = true; kapý.kapilarindex = 2;
        }
    
    }
}