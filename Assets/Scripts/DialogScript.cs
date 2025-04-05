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
    public GameManager gameManager;
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
            gameManager.kamera3.enabled = false;
            gameManager.kamera2.enabled = true;
            gameManager.PlayerScript.gameObject.SetActive(true);
            index = 0;
        }

    }
}
