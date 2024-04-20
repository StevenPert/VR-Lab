using UnityEngine;
using System.Collections;

public class DisableColliderOnTrigger : MonoBehaviour
{
    public Collider targetCollider; // Collider to disable
    public Rigidbody objectRigidbody; // Rigidbody of the object to unfreeze
    public AudioClip soundEffect; // Sound to play when triggered

    private bool rotationFrozen = true; // Flag to track if rotation is frozen

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

            // Unfreeze the Z axis of the object
            if (objectRigidbody != null)
            {
                objectRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
            }
            else
            {
                Debug.LogWarning("Object Rigidbody is not assigned!");
            }

            // Play the sound effect
            if (soundEffect != null)
            {
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }
            else
            {
                Debug.LogWarning("Sound effect is not assigned!");
            }

            // Start the coroutine to freeze rotation after 5 seconds
            StartCoroutine(FreezeRotationAfterDelay(5f));
        }
    }

    private IEnumerator FreezeRotationAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Check if rotation is not already frozen and the object Rigidbody is assigned
        if (!rotationFrozen && objectRigidbody != null)
        {
            // Freeze rotation
            objectRigidbody.constraints |= RigidbodyConstraints.FreezeRotation;
            rotationFrozen = true;
        }
    }
}
