using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject _telepotPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject _textPanel;
    [SerializeField] private GameObject _moneyPanel;

    private void Update()
    {
        EnactiveText();
    }
    private void OnCollisionEnter(Collision collision)
    {
        player.transform.position = _telepotPoint.transform.position;
        _textPanel.SetActive(true);
        _moneyPanel.SetActive(true);
    }
    private void EnactiveText()
    {
        if (Input.anyKey)
        {
            _textPanel.SetActive(false);
        }
    }
}
