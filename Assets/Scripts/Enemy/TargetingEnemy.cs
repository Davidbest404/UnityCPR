using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float startTime;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform rotateZone;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private LayerMask _layerMask2;
    private Vector3 _shootPosition;
    private float currTime;
    private bool isFollowingPlayer = false;

    private void Awake()
    {
        currTime = startTime;
    }
    private void Update()
    {
        if (isFollowingPlayer)
        {
            currTime -= Time.deltaTime;
            if (currTime <= 0)
            {
                currTime = startTime;
                _shootPosition = shootPosition.TransformPoint(Vector3.zero);
                Vector3 rot = shootPosition.rotation.eulerAngles;
                rot = new(rot.x, rot.y, rot.z - 90);
                Quaternion rotQ = Quaternion.Euler(rot);
                Instantiate(bulletPref, _shootPosition, rotQ);
            }
        }
        Vector2 dir = Player.position - rotateZone.position; 
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotateZone.transform.rotation = Quaternion.Euler(0, 0, angle);
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
        if (LayerMaskUtil.ContainsLayer(_layerMask2, collision.gameObject.layer))
        {
            Destroy(gameObject);
        }
    }
}
