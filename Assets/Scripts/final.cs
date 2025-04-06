using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class final : MonoBehaviour
{
    [SerializeField] GameObject[] sayfa;
    public Transform kamera;
    public Transform text;
    [SerializeField] private TMP_Text DialogText;
    [SerializeField] private string[] cumleler;
    [SerializeField] private float yazmaHýzý = 0.001f;

    private int index = 0;
    private int aktifSayfaIndex = 0;
    private bool yaziyorMu = false;

    void Start()
    {
        StartCoroutine(Yaz());
    }

    IEnumerator Yaz()
    {
        yaziyorMu = true;
        DialogText.text = "";

        foreach (char harf in cumleler[index].ToCharArray())
        {
            DialogText.text += harf;
            yield return new WaitForSeconds(yazmaHýzý);
        }

        yaziyorMu = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !yaziyorMu)
        {
            index++;
            aktifSayfaIndex++;

            if (index < cumleler.Length)
            {
                StartCoroutine(Yaz());
            }

            if (aktifSayfaIndex < sayfa.Length)
            {
                KameraKonumGuncelle(aktifSayfaIndex);
            }
        }
    }

    void KameraKonumGuncelle(int index)
    {
        switch (index)
        {
            
            case 2:
                kamera.position = new Vector3(19.82f, 0, -10);
                break;
            case 3:
                kamera.position = new Vector3(42.3f, 0, -10);
                break;
            case 4:
                kamera.position = new Vector3(60.95f, 0, -10);
                break;
        }
    }
}
