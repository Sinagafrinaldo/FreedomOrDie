using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public float healthAmount = 40f; // Jumlah kesehatan yang ditambahkan saat berinteraksi
    public float maxHealth = 100f; // Batas maksimal kesehatan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Hanya berinteraksi jika belum ditampilkan sebelumnya
        {
            playerHealth player = other.gameObject.GetComponent<playerHealth>();

            if (player != null)
            {
                float newHealth = player.health + healthAmount;

                if (newHealth > maxHealth)
                {
                    player.health = 100f; // Tetapkan kesehatan ke batas maksimal jika melebihi
                }
                else
                {
                    player.health = newHealth; // Tambahkan jumlah kesehatan jika masih dalam batas maksimal
                }
            }

            Destroy(gameObject);
        }
    }
}
