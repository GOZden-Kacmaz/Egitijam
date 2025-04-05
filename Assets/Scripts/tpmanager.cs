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
        gamemanagersc.kamera2.enabled = false;
        gamemanagersc.kamera3.enabled = false;
        gamemanagersc.kamera1.enabled = true;
        gamemanagersc.tpmenu.SetActive(false);
        gamemanagersc.PlayerScript.gameObject.transform.position = new Vector3(32, -18, 0);


    }
    public void KarakolTP()
    {
        gamemanagersc.kamera1.enabled = false;
        gamemanagersc.kamera2.enabled = false;
        gamemanagersc.kamera3.enabled = true;
        gamemanagersc.kamera4.enabled = false;
        gamemanagersc.tpmenu.SetActive(false);
        gamemanagersc.PlayerScript.gameObject.transform.position = new Vector3(26, -4, 0);
    }



    void Update()
    {

    }

}
