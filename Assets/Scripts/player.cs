using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] static bool npcdegme = false;
    [SerializeField] static bool ipucuvarmý = false;
    public GameObject dialogmanager;
    public GameManager GameManager;
    int mal;
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
        if (npcdegme == true && Input.GetKeyDown(KeyCode.E) && ipucuvarmý)
        {
            GameManager.kamera2.enabled = false;
            GameManager.kamera3.enabled = true;
            GameManager.kamera4.enabled = false;
            dialogmanager.SetActive(true);
            if (GameManager.kamera1.enabled)
            {
                gameObject.SetActive(false);
                
                
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else if (npcdegme == true && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.dialog.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameManager.tpmenu.SetActive(true);
        }

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("trigger") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(GameManager.ipucu);

            ipucuvarmý = true;

        }
        if (collision.CompareTag("npc"))
        {
            npcdegme = true;
        }
        else
        {
            npcdegme = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("npc")){
            npcdegme = false;
            GameManager.dialog.SetActive(false);
        }
    }

}