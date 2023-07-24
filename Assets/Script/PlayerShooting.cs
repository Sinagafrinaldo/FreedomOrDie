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
    public bool CanShoot;

    void Start()
    {
        CanShoot = false;
    }

    public void PointeDownShoot()
    {
        CanShoot = true;
    }
    public void PointerUpShoot()
    {
        CanShoot = false;
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if ((CanShoot || Input.GetKey(KeyCode.F)) && Time.time > nextFire)
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
