using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] GameObject[] sayfa;
    public Transform kamera;

    private int aktifSayfaIndex = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (sayfa.Length == 0) return;
            
            if (aktifSayfaIndex == 0)
            {
                kamera.position = new Vector3(0.19f,0,-10);
            }
            if (aktifSayfaIndex == 1)
            {
                kamera.position = new Vector3(17.88f, 0, -10);
            }
            if (aktifSayfaIndex == 2)
            {
                kamera.position = new Vector3(36.45f, 0, -10);
            }
            if (aktifSayfaIndex == 3)
            {
                kamera.position = new Vector3(54.76f, 0, -10);
            }
            if (aktifSayfaIndex == 4)
            {
                kamera.position = new Vector3(72.57f, 0, -10);
            }
            if (aktifSayfaIndex == 5)
            {
                kamera.position = new Vector3(91.24f, 0, -10);
            }
            if (aktifSayfaIndex == 6)
            {
                kamera.position = new Vector3(109.6f, 0, -10);
            }
            if (aktifSayfaIndex == 7)
            {
                kamera.position = new Vector3(128.22f, 0, -10);
            }
            aktifSayfaIndex = (aktifSayfaIndex + 1);
            if (aktifSayfaIndex > sayfa.Length)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
