using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public playerHealth pHealth; 
    public float damage = 5;

    private bool alreadyDamaged = false; // damage dalam satu frame

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
            alreadyDamaged = true; 
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alreadyDamaged = false; 
        }
    }
}
