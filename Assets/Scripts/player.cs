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
    private bool kap�temas = false;


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
        if (kap�temas)
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
            Destroy(GameManager.�pucu);
            GameManager.�pucu2.SetActive(true);
            
        }

        if (collision.CompareTag("dosya"))
        {
            GameManager.dosyatake = true;
            Destroy(GameManager.dosya);
        }
        if (collision.CompareTag("ipucu2"))
        {
            GameManager.�pucu2tab.SetActive(true);
        }
        if(collision.CompareTag("cam")&& Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("katilev");
        }
            


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kap�"))
        {

            kap�temas = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kap�"))
        {
            kap�temas = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("npc"))
        {
            npcdegme = false;
            GameManager.dialog.SetActive(false);
        }
        if (collision.CompareTag("kap�1"))
        {
            kap�.kapical = false;

        }
        if (collision.CompareTag("kap�2"))
        {
            kap�.kapical = false;

        }
        if (collision.CompareTag("kap�3"))
        {
            kap�.kapical = false;

        }
        if (collision.CompareTag("ipucu2"))
        {
            GameManager.�pucu2tab.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("kap�1"))
        {
            kap�.kapical = true; kap�.kapilarindex = 0;

            
        }
        if (collision.CompareTag("kap�2"))
        {
                kap�.kapical = true; kap�.kapilarindex = 1;
        }
        if (collision.CompareTag("kap�3"))
        {
            kap�.kapical = true; kap�.kapilarindex = 2;
        }
    
    }
}