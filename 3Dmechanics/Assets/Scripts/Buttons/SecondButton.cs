using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondButton : MonoBehaviour
{
    [SerializeField] private GameObject _wall;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private LayerMask _layerMask2;
    
    private void OnCollisionStay(Collision collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask | _layerMask2, collision.gameObject.layer))
        {
            _wall.SetActive(false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _wall.SetActive(true);
    }
}
