using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    private float timer;
    private AudioSource audioSource;

    private float minShootDelay = 0.5f;
    private float maxShootDelay = 2f;

    private float nextShootTime;

    // Reference to the main camera
    private Camera mainCamera;

    // Set the maximum distance at which the sound will be played
    private float maxSoundDistance = 10f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        nextShootTime = GetNextShootTime();

        mainCamera = Camera.main;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // Check if player is within the desired sound range and visible in the camera viewport
        if (distance < maxSoundDistance && IsPlayerVisibleInCamera())
        {
            timer += Time.deltaTime;
            if (timer >= nextShootTime)
            {
                timer = 0;
                shoot();
                nextShootTime = GetNextShootTime();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        int currentPrefsMusic = PlayerPrefs.GetInt("StateSfx");
        if (currentPrefsMusic == 1)
        {
            audioSource.Play();
        }
        
    }

    float GetNextShootTime()
    {
        return Random.Range(minShootDelay, maxShootDelay);
    }

    bool IsPlayerVisibleInCamera()
    {
        Vector3 playerViewportPos = mainCamera.WorldToViewportPoint(player.transform.position);
        return (playerViewportPos.x >= 0 && playerViewportPos.x <= 1 && playerViewportPos.y >= 0 && playerViewportPos.y <= 1);
    }
}
