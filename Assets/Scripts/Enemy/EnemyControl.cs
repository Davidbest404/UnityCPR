using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyControl : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float Speed;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private LayerMask _layerMask2;
    private bool isFollowingPlayer = false;
    void Update()
    {
        if (isFollowingPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        {
            isFollowingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        { 
            isFollowingPlayer = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (LayerMaskUtil.ContainsLayer(_layerMask2, collision.gameObject.layer))
        {
            Destroy(gameObject);
        }
    }
}
