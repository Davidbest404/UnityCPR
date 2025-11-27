using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEnemy : MonoBehaviour
{
    public int damage = 1;
    public string playerTag = "Player";

    private MyHP playerHP;


    void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag(playerTag).GetComponent<MyHP>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            playerHP.TakeMyDamage(damage);
        }
    }
}

