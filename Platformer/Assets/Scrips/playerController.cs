using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public bool isGrounded;
    public bool isEnemy;

    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;

    public GameObject deathEffect;

    Rigidbody2D rb;
    Collider2D myCollider;
    private Animator anim;
    [SerializeField] private SpriteRenderer spriteRenderer;
    SpriteRenderer sr;
    private Vector3 smoothPosition;

    public VectorValue pos;
    void Start()
    {
        transform.position = pos.initialValue;
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        if (movement > 0) sr.flipX = false;
        if (movement < 0) sr.flipX = true;

        if (movement == 0) States = States.idle;
        if (movement != 0) States = States.run;
    }

    private void Jump()
    {
        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        isEnemy = Physics2D.IsTouchingLayers(myCollider, whatIsEnemy);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                anim.SetTrigger("jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            }
        }
    }
    private States States
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }



}
public enum States
{
    idle,
    run


    
}
