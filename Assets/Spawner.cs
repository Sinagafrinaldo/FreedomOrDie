using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float interval = 150;
    private float counter = 0;
    private float enemycount = 0;
    public float spawnDistanceThreshold = 10f;
    private GameObject player;
    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        counter += 1;

        if (distanceToPlayer < spawnDistanceThreshold)
        {
            if ((counter >= interval) && enemycount < 3)
            {
                counter = 0;
                Instantiate(enemyPrefab, transform.position, transform.rotation);
                enemycount++;
            }
        }

        // if (enemycount >= 3)
        // {
        //     Destroy(GameObject);
        // }
    }
}