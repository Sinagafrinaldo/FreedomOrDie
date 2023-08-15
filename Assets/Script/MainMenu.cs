using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // Periksa apakah sudah ada nilai tersimpan untuk SaveStar, jika belum, beri nilai default 0
        if (!PlayerPrefs.HasKey("SaveStar"))
        {
            PlayerPrefs.SetInt("SaveStar", 0);
        }

        Debug.Log(PlayerPrefs.GetInt("SaveStar"));
    }
    public void PlayGame()
    {
        PauseMenu.isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void KeluarPermainan()
    {
        Debug.Log("Quit! ");
        Application.Quit();
    }
}
