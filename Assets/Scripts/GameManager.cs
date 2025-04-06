using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public player PlayerScript;
    public DialogScript dialogScript;
    public Camera kamera1;
    public Camera kamera3;
    public Camera kamera4;
    public GameObject ıpucu;
    public GameObject ıpucu2;
    public GameObject ıpucu2tab;
    public GameObject dialog;
    public GameObject dialog2;
    public GameObject tpmenu;
    public GameObject dosya;
    public GameObject bulmaca1;
    public GameObject bulmaca2;
    public AudioSource ambience;
    public bool dosyatake;
  
  


    [SerializeField] private bool bulmacaa;
    [SerializeField] private bool[] ipucu1;
    [SerializeField] private Button[] buttons;

    public GameManager gameManager;

    public bool ayakalk;
    private bool ayakalkKullanildi = false;  // Bu kontrol� ekliyoruz

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }

        // Ba�lang��ta ipu�lar� false olsun
        for (int i = 0; i < ipucu1.Length; i++)
        {
            ipucu1[i] = false;
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

    private void OnButtonClicked(int index)
    {
        if (index >= 0 && index < ipucu1.Length)
        {
            ipucu1[index] = true;
        }
    }

    void Update()
    {
        // E�er daha �nce ayakalk i�lemi yap�lmad�ysa kontrol et
        if (!ayakalkKullanildi)
        {
            ayakalk = hepsitruemi();

            if (ayakalk && Input.GetKeyDown(KeyCode.E))
            {
                kamera4.enabled = false;
              
                kamera3.enabled = false;
                kamera1.enabled = true;
                

                PlayerScript.gameObject.SetActive(true);
                PlayerScript.gameObject.transform.position = new Vector3(38.6f, -16.22f, 0);

                // Art�k i�lem yap�ld�, tekrar etmesin
                ayakalkKullanildi = true;
                ayakalk = false;

            }
        }
        if (dosyatake==true)
        {
            bulmaca1.SetActive(false);
            bulmaca2.SetActive(true);

        }
    }
}
