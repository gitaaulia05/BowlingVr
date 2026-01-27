using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class BallRollingSound : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    public float minSpeedToPlay = 0.5f; // kecepatan minimal biar suara nyala
    public float maxSpeed = 15f;        // kecepatan max buat volume/pitch

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float speed = rb.linearVelocity.magnitude;

        if (speed > minSpeedToPlay)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();

            // Volume makin kencang sesuai kecepatan
            audioSource.volume = Mathf.Clamp(speed / maxSpeed, 0.1f, 1f);

            // Pitch sedikit naik biar realistis
            audioSource.pitch = Mathf.Lerp(0.8f, 1.2f, speed / maxSpeed);
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }
}
