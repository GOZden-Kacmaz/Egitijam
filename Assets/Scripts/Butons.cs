using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Butons : MonoBehaviour
{
    [SerializeField] Button[] button;
    [SerializeField] bool[] ipucu;

    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            int index = i; // closure hatasýndan kaçýnmak için
            button[i].onClick.AddListener(() => isaretle(index));
        }
    }

    void isaretle(int index)
    {
        ipucu[index] = true;
    }
}
