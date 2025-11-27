using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float timeAttack = 1f;
    public float nextTimeAttack = 0f;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange = 1;
    public int damage = 1;
    public Animator anim;
    [SerializeField] private AudioSource soundAttack;



    void Update()
    {
        if (Time.time >= nextTimeAttack)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("atack");
                OnAttack();
                nextTimeAttack = Time.time + 1f / timeAttack;
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
        soundAttack.Play();
        anim.SetTrigger("attack");
        soundAttack.Play();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}