using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntEnemyHeathe : MonoBehaviour
{
    public int health = 5;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            anim.SetTrigger("deadAnt");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("haveDamageAnt");

    }
}
