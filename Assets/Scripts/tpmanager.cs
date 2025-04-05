using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpmanager : MonoBehaviour
{
    public GameManager gamemanagersc;
    
    void Start()
    {

    }

    public void EvTP()
    {


        gamemanagersc.kamera1.enabled = false;
        gamemanagersc.kamera2.enabled = false;
        gamemanagersc.kamera3.enabled = true;
        gamemanagersc.kamera4.enabled = true;
        gamemanagersc.tpmenu.SetActive(false);
        gamemanagersc.PlayerScript.gameObject.transform.position = new Vector3(32, -18, 0);



    }



    void Update()
    {

    }

}
