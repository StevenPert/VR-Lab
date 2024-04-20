using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // If there is no AudioSource component, add one and configure it
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 1; // Ensure 3D spatial sound
        }

        // Make sure the AudioClip is assigned to the AudioSource
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
        }
        else
        {
            Debug.LogError("Sound clip is not assigned to the TriggerSound script!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger zone is the player
        if (!hasPlayed && other.CompareTag("Player"))
        {
            // Play the sound
            audioSource.Play();
            hasPlayed = true; // Set the flag to true so the sound won't play again
        }
    }
}
