using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public player PlayerScript;
    public DialogScript dialogScript;
    public Camera kamera1;
    public Camera kamera2;
    public Camera kamera3;
    public Camera kamera4;
    public GameObject ipucu;
    public GameObject dialog;
    public GameObject dialog2;
    public GameObject tpmenu;
    [SerializeField] private bool bulmacaa;
    [SerializeField] private bool[] ipucu1;
    [SerializeField] private Button[] buttons;
    public GameManager gameManager;
    public bool ayakalk;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));

        }
    }
    public bool hepsitruemi()
    {
        foreach (bool deger in ipucu1)
        {
            if (!deger)
                return false;
        }
        return true;
    }
    private void OnButtonClicked(int index)
    {
        if (index >= 0 && index < ipucu1.Length)
        {
            ipucu1[index] = true;
        }
    }
    void Update()
    {
        ayakalk = hepsitruemi();
        if (Input.GetKeyDown(KeyCode.E)&& ayakalk)
        {
            kamera1.enabled = false;
            kamera2.enabled = false;
            kamera3.enabled = false;
            kamera4.enabled = true;

        }

    }
}
