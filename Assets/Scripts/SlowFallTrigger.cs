using UnityEngine;

public class SlowFallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the object with the SlowFall script attached
            SlowFall slowFall = FindObjectOfType<SlowFall>();
            if (slowFall != null)
            {
                slowFall.EnableSlowFall();
            }
        }
    }
}
