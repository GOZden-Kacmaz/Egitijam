using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogScript : MonoBehaviour
{
    [SerializeField] private TMP_Text DialogText;
    [SerializeField] private string[] cumleler;
    [SerializeField] private float yazmaH�z� = 0.05f;
    private int index;

    public GameManager gameManager;

    private bool yaziyorMu = false;

    void Start()
    {
        gameObject.SetActive(false); // Ba�ta g�r�nmesin
    }

    public void Baslat()
    {
        index = 0;
        DialogText.text = "";
        StartCoroutine(Yaz());
    }

    IEnumerator Yaz()
    {
        yaziyorMu = true;
        DialogText.text = "";

        foreach (char harf in cumleler[index])
        {
            DialogText.text += harf;
            yield return new WaitForSeconds(yazmaH�z�);
        }

        yaziyorMu = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !yaziyorMu)
        {
            index++;

            if (index < cumleler.Length)
            {
                StartCoroutine(Yaz());
            }
        }

        if (index >= cumleler.Length)
        {
            gameManager.dialog.SetActive(false); // Diyalog panelini kapat
            gameObject.SetActive(false);         // Diyalog script objesini de gizle
        }
    }
}
