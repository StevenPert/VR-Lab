using UnityEngine;

public class DisableColliderOnTrigger : MonoBehaviour
{
    public Collider targetCollider; // Collider to disable

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the trigger zone's collider
        if (other.CompareTag("Player")) // Adjust the tag as needed
        {
            // Disable the target collider
            if (targetCollider != null)
            {
                targetCollider.enabled = false;
            }
            else
            {
                Debug.LogWarning("Target collider is not assigned!");
            }
        }
    }
}
