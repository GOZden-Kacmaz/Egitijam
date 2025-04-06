using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kapı : MonoBehaviour
{
    public static int kapilarindex;
    public static bool kapical = false;
    public  GameObject[] dialog;
    [SerializeField] public Transform kamera;
    [SerializeField] private TMP_Text[] DialogText;
    [SerializeField] private string[] kapi1cumle;
    [SerializeField] private string[] kapi2cumle;
    [SerializeField] private float yazmaHızı = 0.05f;
    private int index;
    public player player;
    public KameraManager KameraScript;

    private void Start()
    {
        for (int i =0; i == dialog.Length; i++)
        {
            dialog[i].SetActive(false);
        }
        
    }

    void Update()
    {
        // Kapıya yaklaşıldıysa ve E tuşuna basıldıysa
        if (kapical && Input.GetKeyDown(KeyCode.E) && kapilarindex == 0)
        {
            KameraScript.karakterAktif = false;
            dialog[0].SetActive(true);
            kamera.position = new Vector3(0.8f, -11.35f, kamera.position.z);
            player.gameObject.SetActive(false);
            index++;
            if (index < kapi1cumle.Length)
            {
                    StartCoroutine(kapi1yaz());
            }
            if (index >= kapi1cumle.Length)
            {
                dialog[0].SetActive(false);
                kamera.position = new Vector3();
                player.gameObject.SetActive(true);
                KameraScript.karakterAktif = true;
            }
        }
       
        if (kapical && Input.GetKeyDown(KeyCode.E) && kapilarindex == 1)
        {
            KameraScript.karakterAktif = false;
            dialog[1].SetActive(true);
            kamera.position = new Vector3(19.74f, -11.35f, kamera.position.z);
            player.gameObject.SetActive(false);
            index++;
            if (index < kapi2cumle.Length)
            {
                StartCoroutine(kapi2yaz());
            }
            if (index >= kapi2cumle.Length)
            {
                dialog[1].SetActive(false);
                kamera.position = new Vector3();
                player.gameObject.SetActive(true);
                KameraScript.karakterAktif = true;
            }
        }
       
       
      
        
    }
    IEnumerator kapi1yaz()
    {
        DialogText[0].text = "";

        foreach (char harf in kapi1cumle[index])
        {
            DialogText[1].text += harf;
            yield return new WaitForSeconds(yazmaHızı);
        }
    }
    IEnumerator kapi2yaz()
    {
        DialogText[1].text = "";

        foreach (char harf in kapi2cumle[index])
        {
            DialogText[2].text += harf;
            yield return new WaitForSeconds(yazmaHızı);
        }
    }

}
