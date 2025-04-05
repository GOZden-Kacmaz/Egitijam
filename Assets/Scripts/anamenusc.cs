using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anamenusc : MonoBehaviour
{    
    public GameObject anamenu;
    public GameObject ayarlar;
   
    
    
    public  void  oyunbasla()
    {

        SceneManager.LoadScene(1);

    }
    public void ayarlarmenu()
    {
        anamenu.SetActive(false);
        ayarlar.SetActive(true);
    }
    public void returntuþ()
    {
        anamenu.SetActive(true);
        ayarlar.SetActive(false);
    }
    public void oyunuKapat()
    {
        Application.Quit();
    }
    void Update()
    {
        
    }
}
