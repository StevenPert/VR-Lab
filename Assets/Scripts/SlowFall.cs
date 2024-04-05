using UnityEngine;

public class SlowFall : MonoBehaviour
{
    public float fallSpeed = 1f; // Adjustable variable for falling speed
    private bool isTriggered = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity initially
    }

    private void Update()
    {
        if (isTriggered)
        {
            rb.useGravity = true; // Enable gravity for slow fall
            rb.velocity = Vector3.down * fallSpeed; // Set the downward velocity
        }
        else
        {
            rb.useGravity = false; // Disable gravity when slow fall is disabled
            rb.velocity = Vector3.zero; // Stop the object's movement
        }
    }

    public void EnableSlowFall()
    {
        isTriggered = true;
    }

    public void DisableSlowFall()
    {
        isTriggered = false;
    }
}
