using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapı : MonoBehaviour
{
    public GameObject kapı1;
    public GameObject kapı2;
    public GameObject kapı3;
    public bool kapıçal = false;

    public DialogScript dialogScript; // Inspector üzerinden atanmalı

    private bool diyalogBasladi = false;

    void Update()
    {
        // Kapıya yaklaşıldıysa ve E tuşuna basıldıysa
        if (kapıçal && !diyalogBasladi && Input.GetKeyDown(KeyCode.E))
        {
            dialogScript.gameObject.SetActive(true); // Diyalog objesini göster
            dialogScript.Baslat();                   // Diyaloğu başlat
            diyalogBasladi = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("kapı1"))
        {
            kapıçal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("kapı1"))
        {
            kapıçal = false;
        }
    }
}
