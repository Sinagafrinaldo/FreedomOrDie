using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    private EnemyHB _HB;
    public static int enemiesKilled = 0;

    public void Start()
    {
        maxHealth = health;
        _HB = GetComponentInChildren<EnemyHB>();

        if (_HB == null)
        {
            // Jika komponen EnemyHB tidak ditemukan, tambahkan komponen baru
            _HB = gameObject.AddComponent<EnemyHB>();
        }

    }

    public void Update()
    {
        if (health <= 0)
        {
            enemiesKilled++;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 5;
            if (_HB != null)
            {
                _HB.UpdateHB(maxHealth, health);
            }
        }
    }
}
