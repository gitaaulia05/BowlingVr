using UnityEngine;

public class PinSoundManager : MonoBehaviour
{
    public static PinSoundManager Instance;

    public AudioClip hitSound;
    public float cooldown = 0.1f;

    private float lastPlayTime;
    private AudioSource audioSource;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitSound(Vector3 position, float force)
    {
        if (Time.time - lastPlayTime < cooldown) return;

        audioSource.transform.position = position;
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(hitSound, Mathf.Clamp(force / 10f, 0.3f, 1f));

        lastPlayTime = Time.time;
    }
}
