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
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameManager.tpmenu.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        { 
            GameManager.tpmenu.SetActive(false);
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
       

       


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("npc")){
            npcdegme = false;
            GameManager.dialog.SetActive(false);
        }
    }
   

}