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
    [SerializeField] static bool ipucuvarmı = false;
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
        if (npcdegme == true && Input.GetKeyDown(KeyCode.E) && ipucuvarmı)
        {
            GameManager.kamera2.enabled = false;
            GameManager.kamera3.enabled = true;
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
        if (Input.GetKeyUp(KeyCode.Tab))
        { 
            GameManager.tpmenu.SetActive(false);
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("trigger") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(GameManager.ipucu);

            ipucuvarmı = true;

        }
        if (collision.CompareTag("npc"))
        {
            npcdegme = true;
        }
        else
        {
            npcdegme = false;
        }
        if (collision.CompareTag("masa") && Input.GetKeyDown(KeyCode.E))
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