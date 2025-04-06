using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpmanager : MonoBehaviour
{
    public GameManager gamemanagersc;

    
    void Start()
    {
        gamemanagersc.kamera4.enabled = false;
    }

    public void EvTP()
    {


        gamemanagersc.kamera4.enabled = false;
        
        gamemanagersc.kamera3.enabled = false;
        gamemanagersc.kamera1.enabled = true;
        
        gamemanagersc.PlayerScript.gameObject.transform.position = new Vector3(-3.36f, -2.87f, 0);
        gamemanagersc.tpmenu.SetActive(false);
        gamemanagersc.ambience.enabled = false;

    }
    public void KarakolTP()
    {

        gamemanagersc.kamera4.enabled = false;
        gamemanagersc.kamera3.enabled=true;
        gamemanagersc.kamera1.enabled = false;
          
        gamemanagersc.PlayerScript.gameObject.transform.position = new Vector3(16.67f, 2f, 0);
        gamemanagersc.tpmenu.SetActive(false);
        gamemanagersc.ambience.enabled = true;
    }



    void Update()
    {

    }

}
