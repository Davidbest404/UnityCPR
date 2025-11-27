using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstButton : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    private void OnCollisionEnter(Collision collision)
    {
        _text.SetActive(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        _text.SetActive(false);
    }
}
