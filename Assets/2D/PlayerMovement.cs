using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public InputActionAsset inputActions;
    private InputAction moveAction;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the character!");
        }

        moveAction = inputActions.FindActionMap("Player").FindAction("Move");
    }

    void OnEnable()
    {
        if (moveAction != null)
        {
            moveAction.Enable();
        }
    }

    void OnDisable()
    {
        if (moveAction != null)
        {
            moveAction.Disable();
        }
    }

    void FixedUpdate()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        Vector3 moveVector = new Vector3(moveInput.x, 0, moveInput.y);
        moveVector = transform.TransformDirection(moveVector.normalized * moveSpeed);

        rb.linearVelocity = new Vector3(moveVector.x, rb.linearVelocity.y, moveVector.z);
    }
}