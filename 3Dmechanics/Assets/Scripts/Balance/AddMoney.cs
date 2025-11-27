using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _howManyMoney;
    [SerializeField] private float _money = 0f;
    [SerializeField] private float _howManyAddMoney = 1f;
    [SerializeField] private LayerMask _layerMaskMoney;

    private void Awake()
    {
        _howManyMoney.text = $"{_money}";
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMaskMoney, collision.gameObject.layer))
        {
            _money += _howManyAddMoney;
            _howManyMoney.text = $"{_money}";
        }
    }
}
