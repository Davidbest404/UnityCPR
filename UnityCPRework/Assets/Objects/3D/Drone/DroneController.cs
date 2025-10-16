using UnityEngine;
using UnityEngine.InputSystem;

public class DroneController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float up_down_axis, forward_backward_axis, right_left_axis;
    [SerializeField] private float forward_backward_angel = 0, right_left_angel = 0;

    [SerializeField] public float speed, angel;

    [SerializeField] public InputActionAsset inputActions;
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction sprintAction;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        moveAction = inputActions.FindActionMap("Player").FindAction("Move");
        sprintAction = inputActions.FindActionMap("Player").FindAction("Up_Down");
    }

    void Controlls()
    {
    }
}
