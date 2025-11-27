using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField, Range(5, 1)] private float rotRightSpeed = 2f;
    [SerializeField, Range(-5, -1)] private float rotLeftSpeed = -2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] KeyCode jumpCode = KeyCode.Space;
    private Rigidbody rb;
    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Controller();
    }

    private void Controller()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(jumpCode) & isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 rotate = new Vector3(0, rotLeftSpeed, 0);
            transform.Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 rotate = new Vector3(0, rotRightSpeed, 0);
            transform.Rotate(rotate);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grounde") || collision.gameObject.CompareTag("Enemy"))
        {
            isGrounded = true;
        }
    }
}
