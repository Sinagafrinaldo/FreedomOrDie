using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float chaseDistance = 10f;
    public float stopDistance = 3f;
    public float patrolDuration = 0.7f; // Durasi pergerakan patrol (ke kiri dan ke kanan)

    private GameObject player;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private bool isChasing = false;
    private bool isPatrolling = false; // Menandakan apakah musuh sedang melakukan patrol
    private float patrolTimer = 0f; // Timer untuk menghitung durasi patrol
    private int patrolDirection = 1; // Arah patrol (1 untuk ke kanan, -1 untuk ke kiri)

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < chaseDistance)
        {
            isChasing = true;
            isPatrolling = false; // Hentikan patrol saat musuh sedang mengejar pemain
            Vector3 direction = (player.transform.position - transform.position).normalized;

            if (direction.x < 0)
            {
                myAnimator.SetBool("isRunning", true);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (direction.x > 0)
            {
                myAnimator.SetBool("isRunning", true);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                myAnimator.SetBool("isRunning", false);
            }

            if (distanceToPlayer > stopDistance)
            {
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
                myAnimator.SetBool("isRunning", false);
            }
        }
        else
        {
            if (isChasing)
            {
                myAnimator.SetBool("isRunning", false);
                isChasing = false;
            }

            // Jika tidak sedang mengejar atau memburu pemain, lakukan patrol
            if (!isPatrolling)
            {
                StartPatrol();
            }
            else
            {
                Patrol();
            }
        }
    }

    // Memulai patrol
    void StartPatrol()
    {
        isPatrolling = true;
        patrolTimer = 0f;

        // Acak arah patrol antara ke kiri (-1) atau ke kanan (1)
        patrolDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        // Mengubah orientasi musuh sesuai arah patrol
        if (patrolDirection == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (patrolDirection == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Melakukan pergerakan patrol
    void Patrol()
    {
        patrolTimer += Time.deltaTime;
        rb.velocity = new Vector2(moveSpeed * patrolDirection, rb.velocity.y);

        // Mengaktifkan animasi isRunning saat musuh melakukan patrol
        if (Mathf.Abs(rb.velocity.x) > 0)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }

        // Jika durasi patrol telah mencapai patrolDuration, hentikan patrol
        if (patrolTimer >= patrolDuration)
        {
            rb.velocity = Vector2.zero;
            myAnimator.SetBool("isRunning", false);
            isPatrolling = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Mengabaikan sentuhan dengan musuh
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}
