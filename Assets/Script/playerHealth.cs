using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public Animator animator;
    private bool isDead;
    private PlayerMovement playerMovement;
    private PlayerShooting playerShooting;
    public BoxCollider2D Collider;
    public Vector2 Deadsize;
    private float timeScaleDelay = 1.1f; // Waktu penundaan sebelum mengubah Time.timeScale menjadi 0

    public GameObject gameOverUI; // Objek Game Over

    void Start()
    {
        maxHealth = health;
        animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        isDead = false;
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponent<PlayerShooting>();

        // Menonaktifkan objek Game Over saat permainan dimulai
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        
        animator.SetBool("isDead", true);
        Collider.size = Deadsize;
        playerMovement.enabled = false; // Menonaktifkan komponen PlayerMovement
        playerShooting.enabled = false; // Menonaktifkan komponen PlayerShooting

        StartCoroutine(DelayTimeScaleChange());

        // Mengaktifkan objek Game Over
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    IEnumerator DelayTimeScaleChange()
    {
        yield return new WaitForSeconds(timeScaleDelay);
        Time.timeScale = 0f; // Menghentikan skala waktu pada game
    }
}
