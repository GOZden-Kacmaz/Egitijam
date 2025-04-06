using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraManager : MonoBehaviour
{
    public GameObject karakter;
    public Camera cam;
    public float smoothSpeed = 1f;  // Kameran�n yumu�ak hareket h�z�n� ayarlamak i�in de�i�ken
    public Vector3 offset;  // Kameran�n karaktere olan ofseti
    public bool karakterAktif = true;  // Karakterin aktif olup olmad���n� kontrol eden de�i�ken

    // Kameran�n hareket etmeyece�i s�n�rlar
    public Vector3 minPozisyon;  // Kameran�n minimum pozisyonu
    public Vector3 maxPozisyon;  // Kameran�n maksimum pozisyonu

    void Start()
    {
        // Kameran�n ba�lang�� ofseti
        offset = cam.transform.position - karakter.transform.position;
    }

    void Update()
    {
        if (karakterAktif)
        {
            // Kameran�n hedef pozisyonunu hesapla (karakteri ortalayacak �ekilde)
            Vector3 hedefPozisyon = karakter.transform.position + offset;

            // Y eksenini sabit tutarak sadece X ve Z eksenlerinde yumu�ak hareket sa�la
            hedefPozisyon.y = cam.transform.position.y;  // Y de�erini sabitle

            // Kameray� otomatik olarak karakterin ortas�nda tut
            hedefPozisyon.x = Mathf.Clamp(hedefPozisyon.x, minPozisyon.x, maxPozisyon.x);
            hedefPozisyon.z = Mathf.Clamp(hedefPozisyon.z, minPozisyon.z, maxPozisyon.z);

            // Kameray� hedef pozisyona do�ru yumu�ak�a hareket ettir
            Vector3 smoothedPosition = Vector3.Lerp(cam.transform.position, hedefPozisyon, smoothSpeed * Time.deltaTime);

            // Kameray� yeni pozisyona ayarla
            cam.transform.position = smoothedPosition;
        }
    }

    // Karakterin aktif olup olmad���n� kontrol eden fonksiyon
    public void SetKarakterActive(bool aktifMi)
    {
        karakterAktif = aktifMi;

        // Karakteri aktif veya pasif yap
        karakter.SetActive(aktifMi);
    }
}
