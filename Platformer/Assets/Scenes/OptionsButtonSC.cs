using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButtonSC : MonoBehaviour
{
    [SerializeField] public Button OpenOptions;
    [SerializeField] public Button CloseOptions;
    [SerializeField] public Button PlayTheGame;
    [SerializeField] public GameObject OptionsMenu;

    void Start()
    {
        OptionsMenu.SetActive(false);
        OpenOptions.onClick.AddListener(Open);
        CloseOptions.onClick.AddListener(Close);
    }

    public void Open()
    {
        OpenOptions.gameObject.SetActive(false);
        PlayTheGame.gameObject.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void Close()
    {
        OptionsMenu.SetActive(false);
        OpenOptions.gameObject.SetActive(true);
        PlayTheGame.gameObject.SetActive(true);
    }
}
