using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletEffect;
    public Transform bulletPos;
    public Transform effectPos; // Posisi baru untuk efek partikel
    public float fireRate = 0.2f;
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
        // Memainkan suara tembakan
        audioSource.PlayOneShot(shootSound);

        // Menampilkan efek partikel pada posisi effectPos
        GameObject effect = Instantiate(bulletEffect, effectPos.position, effectPos.rotation);

        // Menghancurkan efek partikel setelah 0.1 detik
        Destroy(effect, 0.1f);

        // Membuat peluru yang keluar dari bulletPos
        Instantiate(bullet, bulletPos.position, bulletPos.rotation);
    }
}
