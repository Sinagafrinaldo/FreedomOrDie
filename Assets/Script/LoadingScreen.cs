using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 


public class LoadingScreen : MonoBehaviour
{
    public GameObject loaderUI;
    public Slider progressSlider;
        public TextMeshProUGUI loadingText;

    public void LoadScene(int index)
    {
        // PauseMenu.isPaused = false;
        Time.timeScale = 1f;
        StartCoroutine(LoadScene_Coroutine(index));
        PauseMenu.isPaused = false;
        enemyHealth.enemiesKilled = 0;
    }

    
    public void LoadSceneFromMenu()
    {
        // PauseMenu.isPaused = false;
        if (!PlayerPrefs.HasKey("LastLevel"))
        {
            PlayerPrefs.SetInt("LastLevel", 1);
        }
        int lastLevel = PlayerPrefs.GetInt("LastLevel");

        Time.timeScale = 1f;
        StartCoroutine(LoadScene_Coroutine(lastLevel));
        PauseMenu.isPaused = false;
        enemyHealth.enemiesKilled = 0;
    }

    public void LoadSceneRestart(int index)
    {
        // PauseMenu.isPaused = false;
        Time.timeScale = 1f;
        StartCoroutine(LoadScene_Coroutine(index));
        PauseMenu.isPaused = false;
        enemyHealth.enemiesKilled = 0;
    }

    private string GetLevelText(int levelIndex)
    {
        string[] levelTexts = { "","Level 1: Perang Pattimura", "Level 2: Lanjutan Perang Pattimura", "Level 3: Peristiwa Pemberontakan Lampung", "Level 4: Lanjutan Pemberontakan Lampung", "Level 5: Peristiwa Pangeran Diponegoro: Pertempuran di Yogyakarta", "Level 6: Peristiwa Pangeran Diponegoro: Pertempuran di Magelang", "Level 7: Peristiwa 10 November 1945 di Surabaya: Persiapan dan Penyerangan", "Level 8: Lanjutan Peristiwa 10 November 1945 di Surabaya: Pengepungan markas musuh", "Level 9: Peristiwa Pertempuran Lima Hari di Semarang: Pertempuran di Kota Lama", "Level 10: Lanjutan Peristiwa Pertempuran Lima Hari di Semarang: Pertempuran di Pegirian", "Level 11: Peristiwa Bandung Lautan Api: Persiapan dan Peristiwa awal", "Level 12: Lanjutan Peristiwa Bandung Lautan Api"  };

        if (levelIndex >= 0 && levelIndex < levelTexts.Length)
        {
            return levelTexts[levelIndex];
        }

        return "Unknown Level";
    }

   public IEnumerator LoadScene_Coroutine(int index)
{
    progressSlider.value = 0;
    loaderUI.SetActive(true);
    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
    asyncOperation.allowSceneActivation = false;

    string levelText = GetLevelText(index);
    loadingText.text = levelText;

    float startTime = Time.time;
    float targetProgress = 1.0f; // Target progress to activate scene

    while (!asyncOperation.isDone)
    {
        float elapsedTime = Time.time - startTime;
        float progress = Mathf.Clamp01(elapsedTime / 2.5f); // Clamp progress between 0 and 1
        progressSlider.value = progress;

        if (progress >= targetProgress)
        {
            asyncOperation.allowSceneActivation = true;
        }

        yield return null;
    }
}

}
