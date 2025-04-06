using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulmaca : MonoBehaviour
{
    private static int enYuksekOrder = 0; // Diðer tüm objelerden yüksek tutar

    private void OnMouseDown()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            enYuksekOrder++;
            sr.sortingOrder = enYuksekOrder;
        }
    }

}
