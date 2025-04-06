using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] GameObject[] sayfa;
    public Transform kamera;
    public Transform text;
    [SerializeField] private TMP_Text DialogText;
    [SerializeField] private string[] cumleler;
    [SerializeField] private float yazmaHızı = 0.001f;
    private int index;
    bool metinBittimi=false;
    void Start()
    {
        StartCoroutine(Yaz());
    }
    IEnumerator Yaz()
    {
        metinBittimi=false;
        foreach (char harf in cumleler[index].ToCharArray())
        {
            DialogText.text += harf;
            yield return new WaitForSeconds(yazmaHızı);
        }
        metinBittimi=true;
    }
    private int aktifSayfaIndex = 1;

    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))&&metinBittimi)
        {
            index++;
            DialogText.text = "";
            StartCoroutine(Yaz());

            if (sayfa.Length == 0) return;
            
            if (aktifSayfaIndex == 1)
            {
                
            }
            if (aktifSayfaIndex == 2)
            {
                kamera.position = new Vector3(17.88f, 5.5f, -10);
                
            }
            if (aktifSayfaIndex == 3)
            {
                kamera.position = new Vector3(36.45f, 5.5f, -10);
            }
            if (aktifSayfaIndex == 4)
            {
                kamera.position = new Vector3(54.76f, 5.5f, -10);
            }
            if (aktifSayfaIndex == 5)
            {
                kamera.position = new Vector3(72.57f, 5.5f, -10);
            }
            if (aktifSayfaIndex == 6)
            {
                kamera.position = new Vector3(91.24f, 5.5f, -10);
            }
            if (aktifSayfaIndex == 7)
            {
                kamera.position = new Vector3(109.6f, 5.5f, -10);
            }
            if (aktifSayfaIndex == 8)
            {
                kamera.position = new Vector3(128.22f, 5.5f, -10);
            }
            if (aktifSayfaIndex == 9)
            {
                kamera.position = new Vector3(143.91f, 5.5f, -10);
            }
            if (aktifSayfaIndex == 10)
            {
                kamera.position = new Vector3(163.15f, 5.5f, -10);
            }
            aktifSayfaIndex = (aktifSayfaIndex + 1);
            if (aktifSayfaIndex > sayfa.Length)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
