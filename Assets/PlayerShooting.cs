using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float fireRate = 0.15f;
    private float nextFire = 0f;
    public AudioSource audioSource;
    public AudioClip shootSound;

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKey(KeyCode.F) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, bulletPos.rotation);

        // Memainkan suara tembakan
        audioSource.PlayOneShot(shootSound);
    }
}
