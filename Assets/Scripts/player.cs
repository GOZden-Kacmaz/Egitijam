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
    public GameObject etuþu;
    private bool kitablýktemas;


    public GameObject dialogmanager;
    public kapý kapýsc;
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

        if(kitablýktemas==true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(5);
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
            
        }
        if (collision.gameObject.CompareTag("kapý"))
        {   
            GameManager.kamera3.enabled = true;
            GameManager.kamera1.enabled = false;
            gameObject.transform.position = new Vector3(16.78f, 2, 0);
        }
        if (collision.CompareTag("dosya"))
        {
            GameManager.dosyatake = true;
            Destroy(GameManager.dosya);
        }
        if(collision.CompareTag("cam")&& Input.GetKeyDown(KeyCode.E)&& kapýsc.final==true)
        {
            SceneManager.LoadScene(4);
        }
            


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("kitaplýk"))
        {
            etuþu.SetActive(true);
            kitablýktemas = true;
        }
       


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kitaplýk"))
        {
            etuþu.SetActive(false);
            kitablýktemas=false;
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