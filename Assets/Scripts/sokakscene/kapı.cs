using TMPro;
using UnityEngine;
using System.Collections;

public class kapı : MonoBehaviour
{
    public static int kapilarindex;
    public static bool kapical = false;
    public bool final = false;
    public GameObject[] dialog;
    [SerializeField] private Transform kamera;
    [SerializeField] private TMP_Text[] DialogText;
    [SerializeField] private string[] kapi1cumle;
    [SerializeField] private string[] kapi2cumle;
    [SerializeField] private string[] kapi3cumle;
    [SerializeField] private float yazmaHızı = 0.05f;

    private int[] index;
    public player player;
    public KameraManager KameraScript;
    private bool dialogComplete = false;

    private void Start()
    {
        index = new int[dialog.Length];

        for (int i = 0; i < dialog.Length; i++)
        {
            dialog[i].SetActive(false);
            index[i] = 0;
        }
    }

    void Update()
    {
        if (kapical && Input.GetKeyDown(KeyCode.E) && !dialogComplete)
        {
            KameraScript.SetKarakterActive(false);

            for (int i = 0; i < index.Length; i++)
            {
                index[i] = 0;
            }

            switch (kapilarindex)
            {
                case 0:
                    dialog[0].SetActive(true);
                    kamera.position = new Vector3(0.95f, -11.69f, kamera.position.z);
                    StartCoroutine(KapiYaz(kapi1cumle, 0));
                    break;
                case 1:
                    dialog[1].SetActive(true);
                    kamera.position = new Vector3(21.67f, -11.69f, kamera.position.z);
                    StartCoroutine(KapiYaz(kapi2cumle, 1));
                    break;
                case 2:
                    dialog[2].SetActive(true);
                    kamera.position = new Vector3(43.58f, -11.69f, kamera.position.z);
                    StartCoroutine(KapiYaz(kapi3cumle, 2));
                    final= true;
                    break;
            }
        }

        if (dialogComplete && Input.GetKeyDown(KeyCode.Space))
        {
            player.gameObject.SetActive(true);

            Vector3 yeniPozisyon;

            if (player.transform.position.x < 0)
            {
                yeniPozisyon = new Vector3(0.7f, 0.42f, -2);
            }
            else
            {
                yeniPozisyon = new Vector3(player.transform.position.x - 3f, 0.42f, -2);
            }

            KameraScript.KameraGecisPozisyonu(yeniPozisyon);
            KameraScript.SetKarakterActive(true);

            dialog[kapilarindex].SetActive(false);
            dialogComplete = false;
        }
    }

    IEnumerator KapiYaz(string[] cumleler, int dialogIndex)
    {
        DialogText[dialogIndex].text = "";

        foreach (char harf in cumleler[index[dialogIndex]])
        {
            DialogText[dialogIndex].text += harf;
            yield return new WaitForSeconds(yazmaHızı);
        }

        index[dialogIndex]++;

        if (index[dialogIndex] < cumleler.Length)
        {
            StartCoroutine(KapiYaz(cumleler, dialogIndex));
        }
        else
        {
            dialogComplete = true;
        }
    }
}
