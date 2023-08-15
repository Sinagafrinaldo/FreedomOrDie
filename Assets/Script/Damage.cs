using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public playerHealth pHealth; // Pastikan ini sudah sesuai dengan nama komponen
    public float damage = 5;

    private bool alreadyDamaged = false; // Tandai apakah pemain sudah terkena damage dalam satu frame

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !alreadyDamaged)
        {
            pHealth.health -= damage;
            other.gameObject.GetComponent<playerHealth>().health -= damage;
            alreadyDamaged = true; // Setel alreadyDamaged menjadi true untuk mencegah damage berulang dalam satu frame
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alreadyDamaged = false; // Setel alreadyDamaged menjadi false ketika pemain meninggalkan collider spike
        }
    }
}
