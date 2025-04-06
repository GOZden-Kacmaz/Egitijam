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
    public GameObject Ä±pucu;
    public GameObject Ä±pucu2;
    public GameObject Ä±pucu2tab;
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
<<<<<<< HEAD
    private bool ayakalkKullanildi = false;
=======
    private bool ayakalkKullanildi = false;  // Bu kontrolï¿½ ekliyoruz
>>>>>>> 5863d15acdb5a2c9895e782d371160adaa12b9f7

    private void Start()
    {
        // 1. bulmaca butonlarý
        for (int i = 0; i < bulmaca1buttons.Length; i++)
        {
            int index = i;
            bulmaca1buttons[i].onClick.AddListener(() => OnBulmacaButtonClicked(index));
        }

<<<<<<< HEAD
        // 2. bulmaca butonlarý (PLAKA eþleþmesi DÜZELTÝLDÝ)
        for (int i = 0; i < butonlar.Length; i++)
        {
            int index = i;
            butonlar[i].onClick.AddListener(() => OnPlakaButtonClicked(index));
        }

        // Baþlangýçta tüm bool deðerlerini false yap
=======
        // Baï¿½langï¿½ï¿½ta ipuï¿½larï¿½ false olsun
>>>>>>> 5863d15acdb5a2c9895e782d371160adaa12b9f7
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
<<<<<<< HEAD
        if (index >= 0 && index < plaka.Length)
=======
        // Eï¿½er daha ï¿½nce ayakalk iï¿½lemi yapï¿½lmadï¿½ysa kontrol et
        if (!ayakalkKullanildi)
>>>>>>> 5863d15acdb5a2c9895e782d371160adaa12b9f7
        {
            plaka[index] = true;

            if (index < plakalar.Length)
            {
<<<<<<< HEAD
                SpriteRenderer sr = plakalar[index].GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sortingOrder = 500;
                }
=======
                kamera4.enabled = false;
              
                kamera3.enabled = false;
                kamera1.enabled = true;
                

                PlayerScript.gameObject.SetActive(true);
                PlayerScript.gameObject.transform.position = new Vector3(38.6f, -16.22f, 0);

                // Artï¿½k iï¿½lem yapï¿½ldï¿½, tekrar etmesin
                ayakalkKullanildi = true;
                ayakalk = false;

>>>>>>> 5863d15acdb5a2c9895e782d371160adaa12b9f7
            }
        }
    }


    private void KameraVeOyuncuAktifEt()
    {
        kamera1.enabled = true;
        kamera2.enabled = false;
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
            // 1. bulmaca bitince
            if (!dosyatake && hepsitruemi() && Input.GetKeyDown(KeyCode.E))
            {
                KameraVeOyuncuAktifEt();
            }
            // 2. bulmaca (plaka) bitince
            else if (dosyatake && plakahepsitruemi() && Input.GetKeyDown(KeyCode.E))
            {
                KameraVeOyuncuAktifEt();
            }
        }

        // 1. bulmaca tamamlandýysa 2. bulmaca baþlasýn
        if (dosyatake)
        {
            bulmaca1.SetActive(false);
            bulmaca2.SetActive(true);
            ayakalk = false;
            ayakalkKullanildi = false;
        }
    }
}
