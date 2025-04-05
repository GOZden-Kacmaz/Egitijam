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
    [SerializeField] bool npcdegme = false;
    public GameObject dialog;
    public GameObject dialog2;
    public GameObject ipucu;
    [SerializeField] bool ipucuvarmý = false;
    public Camera kamera;
    public Camera kamera1;
    public GameObject dialogmanager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        kamera1.enabled = false;
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
            kamera.enabled = false;
            kamera1.enabled = true;
            dialog2.SetActive(true);
            dialogmanager.SetActive(true);
            if (kamera1.enabled)
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
            dialog.SetActive(true);
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("trigger") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(ipucu);

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
            dialog.SetActive(false);
        }
    }

}