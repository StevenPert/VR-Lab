using UnityEngine;

public class SlowFall : MonoBehaviour
{
    public float fallSpeed = 1f; // Adjustable variable for falling speed
    public AudioClip soundClip; // Sound to play when trigger
    private bool isTriggered = false;
    private bool hasPlayed = false; // Flag to track if sound has been played
    private Rigidbody rb;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity initially

        // Add AudioSource component and configure it
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; // Set to 0 for 2D audio

        // Make sure the AudioClip is assigned to the AudioSource
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
        }
        else
        {
            Debug.LogError("Sound clip is not assigned to the SlowFall script!");
        }
    }

    private void Update()
    {
        if (isTriggered)
        {
            rb.useGravity = true; // Enable gravity for slow fall
            rb.velocity = Vector3.down * fallSpeed; // Set the downward velocity

            // Check if the sound hasn't been played yet
            if (!hasPlayed)
            {
                // Play the sound
                audioSource.Play();
                hasPlayed = true; // Set the flag to true so the sound won't play again
            }
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

    // Function to be called when the button is poked in Unity VR
    public void OnButtonPoke()
    {
        EnableSlowFall(); // Trigger slow fall when the button is poked
    }
}
