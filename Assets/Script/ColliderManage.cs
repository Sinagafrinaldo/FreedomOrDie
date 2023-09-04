using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            // Mengabaikan sentuhan dengan musuh
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}
