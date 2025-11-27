using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHeathe : MonoBehaviour
{
    public int health = 5;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            anim.SetTrigger("dead");
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("haveDamage");

    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}