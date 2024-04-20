using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject objectToMove; // Reference to the object you want to move
    public float distanceToMove = 5f; // Distance to move the object
    public float moveSpeed = 1.0f; // Speed at which the object moves

    private Vector3 initialPosition; // Initial position of the object

    void Start()
    {
        // Store the initial position of the object
        initialPosition = objectToMove.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Calculate the new position by moving the object forward by the specified distance
            Vector3 newPosition = initialPosition + objectToMove.transform.forward * distanceToMove;

            // Move the object to the new position with specified speed
            StartCoroutine(MoveObject(objectToMove.transform, newPosition, moveSpeed));
        }
    }

    // Coroutine to move the object smoothly to the target position
    IEnumerator MoveObject(Transform objectTransform, Vector3 targetPosition, float speed)
    {
        float startTime = Time.time;
        Vector3 startPosition = objectTransform.position;
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float journeyDuration = journeyLength / speed;

        while (Time.time < startTime + journeyDuration)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            objectTransform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }

        // Ensure the object reaches exactly the target position
        objectTransform.position = targetPosition;
    }
}



