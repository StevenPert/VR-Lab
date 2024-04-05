using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    private void Update()
    {
        bool isGrounded = IsGrounded();

        if (jumpButton.action.triggered && isGrounded)
        {
            Jump();
        }

        movement.y += gravity * Time.deltaTime;

        cc.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private bool IsGrounded()
    {
        // Using a small capsule to check for ground instead of CheckSphere
        return Physics.CheckCapsule(cc.bounds.center, cc.bounds.center - new Vector3(0, cc.bounds.extents.y - 0.1f, 0), cc.bounds.extents.y + 0.1f, groundLayers);
    }
}

