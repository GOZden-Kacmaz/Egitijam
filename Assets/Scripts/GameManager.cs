using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public player PlayerScript;
    public DialogScript dialogScript;
    public Camera kamera1;
    public Camera kamera3;
    public Camera kamera4;
    public GameObject ipucu;
    public GameObject ipucu2;
    public GameObject ipucu2tab;
    public GameObject dialog;
    public GameObject dialog2;
    public GameObject tpmenu;
    public GameObject dosya;
    public GameObject bulmaca1;
    public GameObject bulmaca2;
    public AudioSource ambience;
    public bool dosyatake;

    public Button[] butonlar;
    public GameObject[] plakalar;
    public bool[] plaka;

    [SerializeField] private bool bulmacaa;
    [SerializeField] private bool[] ipucu1;
    [SerializeField] private Button[] bulmaca1buttons;

    public GameManager gameManager;

    public bool ayakalk;
    private bool ayakalkKullanildi = false;

    private void Start()
    {
        // 1. bulmaca butonlarý
        for (int i = 0; i < bulmaca1buttons.Length; i++)
        {
            int index = i;
            bulmaca1buttons[i].onClick.AddListener(() => OnBulmacaButtonClicked(index));
        }

        // 2. bulmaca butonlarý (PLAKA eþleþmesi)
        for (int i = 0; i < butonlar.Length; i++)
        {
            int index = i;
            butonlar[i].onClick.AddListener(() => OnPlakaButtonClicked(index));
        }

        // Baþlangýçta bool dizilerini sýfýrla
        for (int i = 0; i < ipucu1.Length; i++)
        {
            ipucu1[i] = false;
        }

        for (int i = 0; i < plaka.Length; i++)
        {
            plaka[i] = false;
        }
    }

    public bool hepsitruemi()
    {
        foreach (bool deger in ipucu1)
        {
            if (!deger)
                return false;
        }
        return true;
    }

    public bool plakahepsitruemi()
    {
        foreach (bool deger in plaka)
        {
            if (!deger)
                return false;
        }
        return true;
    }

    private void OnBulmacaButtonClicked(int index)
    {
        if (index >= 0 && index < ipucu1.Length)
        {
            ipucu1[index] = true;
        }
    }

    private void OnPlakaButtonClicked(int index)
    {
        if (index >= 0 && index < plaka.Length && !ayakalkKullanildi)
        {
            plaka[index] = true;

            if (index < plakalar.Length)
            {
                SpriteRenderer sr = plakalar[index].GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sortingOrder = 500;
                }
            }

            kamera4.enabled = false;
            kamera3.enabled = false;
            kamera1.enabled = true;

            PlayerScript.gameObject.SetActive(true);
            PlayerScript.gameObject.transform.position = new Vector3(38.6f, -16.22f, 0);

            ayakalkKullanildi = true;
            ayakalk = false;
        }
    }

    private void KameraVeOyuncuAktifEt()
    {
        kamera1.enabled = true;
        kamera3.enabled = false;
        kamera4.enabled = false;

        PlayerScript.gameObject.SetActive(true);
        PlayerScript.gameObject.transform.position = new Vector3(38.6f, -16.22f, 0);

        ayakalkKullanildi = true;
        ayakalk = false;
    }

    void Update()
    {
        if (!ayakalkKullanildi)
        {
            // 1. bulmaca tamamlandýysa
            if (!dosyatake && hepsitruemi() && Input.GetKeyDown(KeyCode.E))
            {
                KameraVeOyuncuAktifEt();
            }
            // 2. bulmaca tamamlandýysa (plakalar)
            else if (dosyatake && plakahepsitruemi() && Input.GetKeyDown(KeyCode.E))
            {
                KameraVeOyuncuAktifEt();
            }
        }

        // Dosya alýndýysa 2. bulmacayý aktif et
        if (dosyatake)
        {
            bulmaca1.SetActive(false);
            bulmaca2.SetActive(true);
            ayakalk = false;
            ayakalkKullanildi = false;
        }
    }
}
