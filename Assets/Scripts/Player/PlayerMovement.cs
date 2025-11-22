using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private LayerMask _layerMask;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        {
            _rb.velocity = Vector2.zero;
        }
    }

    public void Move(Vector2 direction)
    {
        if (_rb != null)
            _rb.velocity = direction * speed;
    }
}
