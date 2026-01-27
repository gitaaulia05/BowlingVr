using UnityEngine;
using UnityEngine.InputSystem;

public class ShootBall : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootForce = 800f;

    void Update()
    {
        // Klik kanan mouse (Input System)
        if (Mouse.current != null &&
            Mouse.current.rightButton.wasPressedThisFrame)
        // Klik KANAN mouse (Input System)
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 spawnPos = transform.position + transform.forward * 0.5f;

        GameObject bullet = Instantiate(
            bulletPrefab,
            spawnPos,
            Quaternion.identity
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce);
    }
}
