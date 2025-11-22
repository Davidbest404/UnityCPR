using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private int timeDestroy;
    [SerializeField] private int speed;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, timeDestroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
