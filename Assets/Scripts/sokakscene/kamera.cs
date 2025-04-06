using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraManager : MonoBehaviour
{
    public GameObject karakter;
    public Camera cam;
    public float smoothSpeed = 1f;
    public Vector3 offset;
    public bool karakterAktif = true;

    public Vector3 minPozisyon;
    public Vector3 maxPozisyon;

    void Start()
    {
        offset = cam.transform.position - karakter.transform.position;

        if (minPozisyon == maxPozisyon)
        {
            Debug.LogWarning("Kamera sýnýrlarý ayarlanmadý!");
        }
    }

    void LateUpdate()
    {
        if (!karakterAktif) return;

        Vector3 hedefPozisyon = karakter.transform.position + offset;
        hedefPozisyon.y = cam.transform.position.y;

        hedefPozisyon.x = Mathf.Clamp(hedefPozisyon.x, minPozisyon.x, maxPozisyon.x);
        hedefPozisyon.z = Mathf.Clamp(hedefPozisyon.z, minPozisyon.z, maxPozisyon.z);

        Vector3 smoothedPosition = Vector3.Lerp(cam.transform.position, hedefPozisyon, smoothSpeed * Time.deltaTime);
        cam.transform.position = smoothedPosition;
    }

    public void SetKarakterActive(bool aktifMi)
    {
        karakterAktif = aktifMi;
        karakter.SetActive(aktifMi);
    }

    public void KameraGecisPozisyonu(Vector3 hedefPozisyon)
    {
        cam.transform.position = hedefPozisyon;
        offset = cam.transform.position - karakter.transform.position;
    }
}
