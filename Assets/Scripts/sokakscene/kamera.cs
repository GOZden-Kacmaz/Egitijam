using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public GameObject karakter;
    public Camera cam;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (karakter.transform.position.x > 10)
        {
            cam.transform.position = new Vector3(16.95f,0.85f,-2f);
        }
        else
        {
            cam.transform.position = new Vector3(0.8f,0.85f ,-2f);
        }
    }
}
