using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundAndCrateLayers; // Combined layer mask for ground and crate

    private float gravity = Physics.gravity.y;
    private Vector3 movement;
    private bool canJump = true; // Flag to track if the player can jump

    [SerializeField] private float jumpCooldown = 1.5f; // Cooldown time in seconds
    private bool isCooldown = false; // Flag to track if the jump is on cooldown

    private void Update()
    {
        bool isGrounded = IsGrounded();

        // Check if jump button is pressed, player is grounded, and jump is not on cooldown
        if (jumpButton.action.triggered && isGrounded && canJump && !isCooldown)
        {
            Jump();
            StartCoroutine(JumpCooldown());
        }

        movement.y += gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        canJump = false; // Disable jumping until cooldown is over
    }

    private IEnumerator JumpCooldown()
    {
        isCooldown = true; // Set jump on cooldown
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true; // Enable jumping after cooldown
        isCooldown = false; // Reset cooldown flag
    }

    private bool IsGrounded()
    {
        // CheckCapsule with combined layer mask for ground and crate
        return Physics.CheckCapsule(cc.bounds.center, cc.bounds.center - new Vector3(0, cc.bounds.extents.y - 0.1f, 0), cc.bounds.extents.y + 0.1f, groundAndCrateLayers);
    }
}
