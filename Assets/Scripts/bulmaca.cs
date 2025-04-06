using UnityEngine;
using UnityEngine.UI;

public class ClickToTopManager : MonoBehaviour
{
    public GameObject[] nesneler; // 5 nesne burada atanacak

    void Start()
    {
        // Ba�lang��ta t�m nesnelerin s�ras�n� s�f�rl�yoruz
        foreach (GameObject nesne in nesneler)
        {
            var sr = nesne.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sortingOrder = 0;
        }
    }

    // Her bir GameObject'e eklenen OnMouseDown fonksiyonu
    void OnMouseDown()
    {
        // Di�er t�m nesnelerin s�ras�n� s�f�rla
        foreach (GameObject nesne in nesneler)
        {
            var sr = nesne.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sortingOrder = 0;
        }

        // T�klanan nesnenin s�ras�n� 10 yap
        var srClicked = GetComponent<SpriteRenderer>();
        if (srClicked != null)
            srClicked.sortingOrder = 10;
    }
    
    
}
