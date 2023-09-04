using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject ButtonUI, TimerUI, PauseUI, ScoreUI;

    private enemyHealth[] enemyHealths; // Array untuk menyimpan referensi ke skrip enemyHealth

    public int maxStarKill;
    public int maxStarTime;
    public int rentangMin;


    private void Start()
    {
       
        enemyHealths = FindObjectsOfType<enemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
             if (activeSceneIndex == 12){
                activeSceneIndex = 0;
             }
            if (!PlayerPrefs.HasKey("LastLevel"))
            {
                PlayerPrefs.SetInt("LastLevel", 1);
            }else{
                PlayerPrefs.SetInt("LastLevel", activeSceneIndex+1);
            }
            totalTime = timer.timeRemaining;

            endGamePanel.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.isPaused = true;

            totalTimeText.text = timer.timeText.text;

            int totalEnemiesKilled = enemyHealth.enemiesKilled;

           
            ButtonUI.SetActive(false);
            TimerUI.SetActive(false);
            PauseUI.SetActive(false);
            ScoreUI.SetActive(false);

         
            if (totalEnemiesKilled >= maxStarKill && totalTime <= maxStarTime)
            {
                star3.SetActive(true);
                int currentStars = PlayerPrefs.GetInt("SaveStar" + SceneManager.GetActiveScene().buildIndex, 0);
                if (currentStars < 3)
                {
                    PlayerPrefs.SetInt("SaveStar" + SceneManager.GetActiveScene().buildIndex, 3);
                }
            }
            else if (totalEnemiesKilled >= rentangMin && totalEnemiesKilled<=maxStarKill )
            {
                star2.SetActive(true); 
                int currentStars = PlayerPrefs.GetInt("SaveStar" + SceneManager.GetActiveScene().buildIndex, 0);
                if (currentStars < 2)
                {
                    PlayerPrefs.SetInt("SaveStar" + SceneManager.GetActiveScene().buildIndex, 2);
                }
            }
            else
            {
                star1.SetActive(true); 
                int currentStars = PlayerPrefs.GetInt("SaveStar" + SceneManager.GetActiveScene().buildIndex, 0);
                if (currentStars < 1)
                {
                    PlayerPrefs.SetInt("SaveStar" + SceneManager.GetActiveScene().buildIndex, 1);
                }
            }

           
            totalSkorText.text = totalEnemiesKilled.ToString();
            enemyHealth.enemiesKilled = 0;
        }
    }
}
