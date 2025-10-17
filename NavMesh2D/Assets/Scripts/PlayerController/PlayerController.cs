using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]  float moveSpeed;
    Rigidbody2D rb;
    PlayerInput controls;
    Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerInput();
    }
    void OnEnable()
    {
        controls.Enable();
        controls.Player.Move.performed += HandleMoveInput;
        controls.Player.Move.canceled += HandleMoveInputCanceled;
    }
    void OnDisable()
    {
        controls.Disable();
        controls.Player.Move.performed -= HandleMoveInput;
        controls.Player.Move.canceled -= HandleMoveInputCanceled;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
    void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    void HandleMoveInputCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }
    void MovePlayer()
    {
        Vector2 moveVelocity = moveInput.normalized * moveSpeed;
        rb.linearVelocity = moveVelocity;
    }
}
