using System.Collections.Generic;
using UnityEngine;

public class SwapScreens : MonoBehaviour
{
    // Ёкраны дл€ переключени€
    [SerializeField] public GameObject fScreen;
    [SerializeField] public GameObject sScreen;
    [SerializeField] public Transform sScreenPos;

    [SerializeField] public bool turn = true;

    // ћетод, вызывающий смену экранов
    public void Open_Close()
    {
        if (turn)
        {
            sScreen.transform.position = fScreen.transform.position;
            fScreen.SetActive(false);
            turn = false;
        }
        else
        {
            sScreen.transform.position = sScreenPos.position;
            fScreen.SetActive(true);
            turn = true;
        }
    }
}