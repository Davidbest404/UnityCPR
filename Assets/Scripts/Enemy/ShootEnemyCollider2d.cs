using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyCollider2d : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask2, collision.gameObject.layer))
        {
            Destroy(gameObject);
        }
    }
}
