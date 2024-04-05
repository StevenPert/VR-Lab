using UnityEngine;

public class SlowFall : MonoBehaviour
{
    public float fallSpeed = 1f; // Adjustable variable for falling speed
    private bool isTriggered = false;

    private void Update()
    {
        if (isTriggered)
        {
            // Move the object down at a slow speed
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
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
