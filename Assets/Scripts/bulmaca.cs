using UnityEngine;
using UnityEngine.UI;

public class ClickToTopManager : MonoBehaviour
{
    public GameObject[] nesneler; // 5 nesne burada atanacak

    void Start()
    {
        // Baþlangýçta tüm nesnelerin sýrasýný sýfýrlýyoruz
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
        // Diðer tüm nesnelerin sýrasýný sýfýrla
        foreach (GameObject nesne in nesneler)
        {
            var sr = nesne.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sortingOrder = 0;
        }

        // Týklanan nesnenin sýrasýný 10 yap
        var srClicked = GetComponent<SpriteRenderer>();
        if (srClicked != null)
            srClicked.sortingOrder = 10;
    }
    
    
}
