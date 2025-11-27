using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public GameObject leftBorder;
    public GameObject rightBorder;
    public Rigidbody2D rb;
    public Animator anim;
    SpriteRenderer sr;

    public bool isRightDirection;

    public float speed;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (isRightDirection)
        {
            rb.velocity = new Vector2(speed, 0);
            if (transform.position.x >= rightBorder.transform.position.x)
                isRightDirection = false;
            sr.flipX = true;

        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            if (transform.position.x <= leftBorder.transform.position.x)
                isRightDirection = true;
            sr.flipX = false;
        }
    }
}
