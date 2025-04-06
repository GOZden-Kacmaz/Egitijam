using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kapı : MonoBehaviour
{
    public static int kapilarindex;
    public static bool kapical = false;
    public static GameObject[] dialog;
    [SerializeField] public Transform kamera;
    [SerializeField] private TMP_Text[] DialogText;
    [SerializeField] private string[] kapi1cumle;
    [SerializeField] private string[] kapi2cumle;
    [SerializeField] private string[] kapi3cumle;
    [SerializeField] private float yazmaHızı = 0.05f;
    private int index;
    public player player;

    private void Start()
    {
        
    }

    void Update()
    {
        // Kapıya yaklaşıldıysa ve E tuşuna basıldıysa
        if (kapical && Input.GetKeyDown(KeyCode.E) && kapilarindex == 1)
        {
            dialog[kapilarindex].SetActive(true);
            
            kamera.position = new Vector3(1.32314f, -14.8703f,kamera.position.z);
            player.gameObject.SetActive(false);
            if (Input.GetMouseButtonDown(0) && kapical && kapilarindex == 1)
            {
                index++;

                if (index < kapi1cumle.Length)
                {
                    StartCoroutine(kapi1yaz());
                }
            }

            if (index >= kapi1cumle.Length)
            {
                dialog[1].SetActive(false);
                kamera.position = new Vector3();
                player.gameObject.SetActive(true);
            }
        }
        else
        {
            dialog[kapilarindex].SetActive(false);
        }
        if (kapical && Input.GetKeyDown(KeyCode.E) && kapilarindex == 2)
        {
            dialog[kapilarindex].SetActive(true);
            kamera.position = new Vector3(20.26f, -14.8703f, kamera.position.z);
            player.gameObject.SetActive(false);
            if (Input.GetMouseButtonDown(0) && kapical && kapilarindex == 1)
            {
                index++;

                if (index < kapi2cumle.Length)
                {
                    StartCoroutine(kapi2yaz());
                }
            }

            if (index >= kapi2cumle.Length)
            {
                dialog[2].SetActive(false);
                kamera.position = new Vector3();
                player.gameObject.SetActive(true);
            }
        }
        else
        {
            dialog[kapilarindex].SetActive(false);
        }
        if (kapical && Input.GetKeyDown(KeyCode.E) && kapilarindex == 3)
        {
            dialog[kapilarindex].SetActive(true);
            kamera.position = new Vector3(20.26f, -14.8703f, kamera.position.z);
            player.gameObject.SetActive(false);
            if (Input.GetMouseButtonDown(0) && kapical && kapilarindex == 1)
            {
                index++;

                if (index < kapi3cumle.Length)
                {
                    StartCoroutine(kapi3yaz());
                }
            }

            if (index >= kapi3cumle.Length)
            {
                dialog[3].SetActive(false);  //dialog panelini kapat
                kamera.position = new Vector3();
                player.gameObject.SetActive(true);
            }
        }
        else
        {
            dialog[kapilarindex].SetActive(false);
        }
        
    }
    IEnumerator kapi1yaz()
    {
        DialogText[kapilarindex].text = "";

        foreach (char harf in kapi1cumle[index])
        {
            DialogText[1].text += harf;
            yield return new WaitForSeconds(yazmaHızı);
        }
    }
    IEnumerator kapi2yaz()
    {
        DialogText[kapilarindex].text = "";

        foreach (char harf in kapi2cumle[index])
        {
            DialogText[2].text += harf;
            yield return new WaitForSeconds(yazmaHızı);
        }
    }

    IEnumerator kapi3yaz()
    {
        DialogText[kapilarindex].text = "";

        foreach (char harf in kapi3cumle[index])
        {
            DialogText[3].text += harf;
            yield return new WaitForSeconds(yazmaHızı);
        }
    }

}
