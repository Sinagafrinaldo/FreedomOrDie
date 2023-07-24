using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingHouse : MonoBehaviour
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
        player = GameObject.FindGameObjectWithTag("House");
        audioSource = GetComponent<AudioSource>();
        nextShootTime = GetNextShootTime();

        mainCamera = Camera.main;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // Check if the house is within the desired sound range and visible in the camera viewport
        if (distance < maxSoundDistance && IsObjectVisibleInCamera(player))
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
        audioSource.Play();
    }

    float GetNextShootTime()
    {
        return Random.Range(minShootDelay, maxShootDelay);
    }

    bool IsObjectVisibleInCamera(GameObject targetObject)
    {
        if (targetObject == null)
            return false;

        Vector3 objectViewportPos = mainCamera.WorldToViewportPoint(targetObject.transform.position);
        return (objectViewportPos.x >= 0 && objectViewportPos.x <= 1 && objectViewportPos.y >= 0 && objectViewportPos.y <= 1);
    }
}
