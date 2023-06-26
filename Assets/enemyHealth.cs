using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float maxHealth;
    private EnemyHB _HB;


    // public Image healthBar;  
    public void Start()
    {
        maxHealth = health;
        _HB = GetComponentInChildren<EnemyHB>();
    }

    // Update is called once per frame
    public void Update()
    {
        // healthBar.fillAmount = Mathf.Clamp(health/maxHealth, 0, 1);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 5;
            _HB.UpdateHB(maxHealth, health);
            // Destroy(gameObject);
        }
    }
}
