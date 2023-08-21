using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {


        // Menampilkan skor awal (0) pada UI
        UpdateScoreText(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Mengupdate skor yang ditampilkan dengan skor dari skrip enemyHealth
        UpdateScoreText(enemyHealth.enemiesKilled);
    }

    void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
