using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletEffect;
    public Transform bulletPos;
    public Transform effectPos; 
    public float fireRate = 0.2f;
    private float nextFire = 0f;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip pickSound;

    public bool CanShoot;
    public GameObject effect;

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
        int currentPrefsMusic = PlayerPrefs.GetInt("StateSfx");
        if (currentPrefsMusic == 1)
        {
            audioSource.PlayOneShot(shootSound);
        }
        
        if (GetComponent<PlayerMovement>().myAnimator.GetBool("isCrouch")) // Jika karakter sedang crouch
        {
            // Mengubah posisi peluru sedikit lebih rendah
            effect = Instantiate(bulletEffect, new Vector3(effectPos.position.x, effectPos.position.y - 0.3f, effectPos.position.z), effectPos.rotation);
        }else{
            effect = Instantiate(bulletEffect, new Vector3(effectPos.position.x, effectPos.position.y , effectPos.position.z), effectPos.rotation);
        }

        // Menghancurkan efek partikel setelah 0.1 detik
        Destroy(effect, 0.1f);

        // Menentukan posisi peluru berdasarkan posisi karakter saat ini
        Vector3 bulletPosition = bulletPos.position;

        if (GetComponent<PlayerMovement>().myAnimator.GetBool("isCrouch")) // Jika karakter sedang crouch
        {
            bulletPosition.y -= 0.3f; 
        }
        Instantiate(bullet, bulletPosition, bulletPos.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("HealthItem")) 
        {
          


        if (!PlayerPrefs.HasKey("StateSfx"))
        {
            PlayerPrefs.SetInt("StateSfx", 1);
        }

        int statesFx = PlayerPrefs.GetInt("StateSfx");

        if (statesFx == 1){
            audioSource.PlayOneShot(pickSound);
        }



        }
    }
}


