using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHouse : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float timer;

    public float upwardOffset; // Nilai offset ke atas yang diinginkan

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("House");
        Vector3 direction = player.transform.position - transform.position;

        // Normalize the direction vector
        direction.Normalize();

        // Apply the upwardOffset
        direction.y += upwardOffset;

        rb.velocity = direction * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            Destroy(gameObject);
        }
    }
}
