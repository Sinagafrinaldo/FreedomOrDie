using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public GameObject endGamePanel;
    public static bool isEnd;
    public Timer timer;
    private float totalTime;
    public TMP_Text totalTimeText;
    public TMP_Text totalSkorText;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private enemyHealth[] enemyHealths; // Array untuk menyimpan referensi ke skrip enemyHealth

    private void Start()
    {
        // Mendapatkan semua komponen enemyHealth yang ada di dalam scene
        enemyHealths = FindObjectsOfType<enemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            totalTime = timer.timeRemaining;

            endGamePanel.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.isPaused = true;

            totalTimeText.text = timer.timeText.text; // Menampilkan total waktu di UI end game

            int totalEnemiesKilled = 0;

            // Menjumlahkan total enemiesKilled dari semua enemyHealth yang ada
            foreach (enemyHealth enemyHealth in enemyHealths)
            {
                totalEnemiesKilled += enemyHealth.enemiesKilled;
            }

            // Periksa apakah semua musuh terbunuh dan waktu kurang dari 20 detik
            if (totalEnemiesKilled == 5 && totalTime < 20)
            {
                star3.SetActive(true); // Dapatkan 3 bintang jika memenuhi kriteria
                int currentStars = PlayerPrefs.GetInt("SaveStar", 0);
                if (currentStars < 3)
                {
                    PlayerPrefs.SetInt("SaveStar", 3);
                }
            }
            else if (totalEnemiesKilled == 5)
            {
                star2.SetActive(true); // Dapatkan 2 bintang jika semua musuh terbunuh, tetapi waktu lebih dari 20 detik
                int currentStars = PlayerPrefs.GetInt("SaveStar", 0);
                if (currentStars < 2)
                {
                    PlayerPrefs.SetInt("SaveStar", 2);
                }
            }
            else
            {
                star1.SetActive(true); // Dapatkan 1 bintang jika ada musuh yang tidak terbunuh
                int currentStars = PlayerPrefs.GetInt("SaveStar", 0);
                if (currentStars < 1)
                {
                    PlayerPrefs.SetInt("SaveStar", 1);
                }
            }


            // Mengatur teks pada inspector totalSkorText dengan totalEnemiesKilled
            totalSkorText.text = totalEnemiesKilled.ToString();
        }
    }
}
