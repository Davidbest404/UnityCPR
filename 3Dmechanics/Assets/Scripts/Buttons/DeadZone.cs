using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject _spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        {
            Instantiate(_gameObject, _spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
