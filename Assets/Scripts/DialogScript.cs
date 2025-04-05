using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogScript : MonoBehaviour
{
    [SerializeField] private TMP_Text DialogText;
    [SerializeField] private string[] cumleler;
    [SerializeField] private float yazmaHýzý =0.001f;
    private int index;
    public player playerscript;
    void Start()
    {
        StartCoroutine(Yaz());
    }
    IEnumerator Yaz()
    {
        foreach(char harf in cumleler[index].ToCharArray())
        {
            DialogText.text += harf;
            yield return new WaitForSeconds(yazmaHýzý);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            index++;
            DialogText.text = "";
            StartCoroutine(Yaz());
        }
        if (index == 4)
        {
            playerscript.kamera1.enabled = false;
            playerscript.kamera.enabled = true;
            playerscript.gameObject.SetActive(true);
        }

    }
}
