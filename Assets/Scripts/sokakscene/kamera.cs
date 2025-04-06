using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraManager : MonoBehaviour
{
    public GameObject karakter;
    public Camera cam;
    public float smoothSpeed = 1f;  // Kameranýn yumuþak hareket hýzýný ayarlamak için deðiþken
    public Vector3 offset;  // Kameranýn karaktere olan ofseti
    public bool karakterAktif = true;  // Karakterin aktif olup olmadýðýný kontrol eden deðiþken

    // Kameranýn hareket etmeyeceði sýnýrlar
    public Vector3 minPozisyon;  // Kameranýn minimum pozisyonu
    public Vector3 maxPozisyon;  // Kameranýn maksimum pozisyonu

    void Start()
    {
        // Kameranýn baþlangýç ofseti
        offset = cam.transform.position - karakter.transform.position;
    }

    void Update()
    {
        if (karakterAktif)
        {
            // Kameranýn hedef pozisyonunu hesapla (karakteri ortalayacak þekilde)
            Vector3 hedefPozisyon = karakter.transform.position + offset;

            // Y eksenini sabit tutarak sadece X ve Z eksenlerinde yumuþak hareket saðla
            hedefPozisyon.y = cam.transform.position.y;  // Y deðerini sabitle

            // Kamerayý otomatik olarak karakterin ortasýnda tut
            hedefPozisyon.x = Mathf.Clamp(hedefPozisyon.x, minPozisyon.x, maxPozisyon.x);
            hedefPozisyon.z = Mathf.Clamp(hedefPozisyon.z, minPozisyon.z, maxPozisyon.z);

            // Kamerayý hedef pozisyona doðru yumuþakça hareket ettir
            Vector3 smoothedPosition = Vector3.Lerp(cam.transform.position, hedefPozisyon, smoothSpeed * Time.deltaTime);

            // Kamerayý yeni pozisyona ayarla
            cam.transform.position = smoothedPosition;
        }
    }

    // Karakterin aktif olup olmadýðýný kontrol eden fonksiyon
    public void SetKarakterActive(bool aktifMi)
    {
        karakterAktif = aktifMi;

        // Karakteri aktif veya pasif yap
        karakter.SetActive(aktifMi);
    }
}
