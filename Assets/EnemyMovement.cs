using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float chaseDistance = 10f;
    public float stopDistance = 3f; // Jarak di mana musuh akan berhenti mengejar pemain

    private GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Menghitung jarak antara pemain dan musuh
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Jika jarak antara pemain dan musuh lebih kecil dari chaseDistance, musuh akan mengejar pemain
        if (distanceToPlayer < chaseDistance)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Menghadapkan musuh ke arah pemain (kiri atau kanan)
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // Menghadap ke kanan
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Menghadap ke kiri
            }

            // Jika jarak antara pemain dan musuh lebih besar dari stopDistance, musuh akan terus bergerak
            if (distanceToPlayer > stopDistance)
            {
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                // Jika jarak antara pemain dan musuh lebih kecil dari stopDistance, musuh akan berhenti
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            // Jika jarak antara pemain dan musuh lebih besar dari chaseDistance, musuh akan berhenti
            rb.velocity = Vector2.zero;
        }
    }
}
