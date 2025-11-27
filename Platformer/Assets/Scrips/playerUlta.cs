using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUlta : MonoBehaviour
{
    public float mytimeAttack = 1f;
    public float mynextTimeAttack = 0f;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange = 1;
    public int damage = 1;
    public Animator anim;

    void Update()
    {
        if (Time.time >= mynextTimeAttack)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                anim.SetTrigger("ulta");
                Debug.Log("atack");
                OnAttack();
                mynextTimeAttack = Time.time + 1f / mytimeAttack;
            }
        }
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyHeathe>().TakeDamage(damage);
            Debug.Log(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
