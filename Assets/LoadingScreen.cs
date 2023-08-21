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

    public void LoadSceneRestart(int index)
    {
        // PauseMenu.isPaused = false;
        Time.timeScale = 1f;
        StartCoroutine(LoadScene_Coroutine(index));
        PauseMenu.isPaused = false;
    }

    private string GetLevelText(int levelIndex)
    {
        string[] levelTexts = { "","Level 1: Perang Pattimura", "Level 2: Lanjutan Perang Pattimura", "Level 3: Peristiwa Pemberontakan Lampung", /* ... */ };

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
