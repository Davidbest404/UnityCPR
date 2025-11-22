using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float startTime;
    private float currTime;

    private void Awake()
    {
        currTime = startTime;
    }
    private void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime <= 0)
        {
            currTime = startTime;
            Instantiate(bulletPref, transform);
        }
    }
}
