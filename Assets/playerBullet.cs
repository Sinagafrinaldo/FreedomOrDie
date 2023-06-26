using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    public float timer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Mendapatkan arah hadapan karakter player
        Vector2 playerForward = transform.right;

        rb.velocity = playerForward * force;

        // Mengubah rotasi peluru agar menghadap arah hadapan karakter
        float rot = Mathf.Atan2(playerForward.y, playerForward.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // health -= 5;
            Destroy(gameObject);
        }
    }
}
