using UnityEngine;

public class ResettablePin : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void ResetPin()
    {
        // Stop physics
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Temporarily disable physics
        rb.isKinematic = true;

        // Reset transform
        transform.position = startPosition;
        transform.rotation = startRotation;

        // Re-enable physics
        rb.isKinematic = false;
    }
}
