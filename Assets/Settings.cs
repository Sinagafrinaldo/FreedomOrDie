using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject onMusicBtn;
    public GameObject offMusicBtn;
    public GameObject onSfxBtn;
    public GameObject offSfxBtn;
    public GameObject onDialog;
    public GameObject offDialog;

    void Start()
    {
        if (!PlayerPrefs.HasKey("StateMusic"))
        {
            PlayerPrefs.SetInt("StateMusic", 1);
        }
        
        int statesInPrefsMusic = PlayerPrefs.GetInt("StateMusic");

        if (!PlayerPrefs.HasKey("StateSfx"))
        {
            PlayerPrefs.SetInt("StateSfx", 1);
        }
        
        int statesInPrefsSfx = PlayerPrefs.GetInt("StateSfx");

        if (!PlayerPrefs.HasKey("StateDialog"))
        {
            PlayerPrefs.SetInt("StateDialog", 1);
        }
        
        int statesInPrefsDialog = PlayerPrefs.GetInt("StateDialog");

        ShowButton(statesInPrefsMusic, statesInPrefsSfx, statesInPrefsDialog);
    }

    public void ShowButton(int musicState, int sfxState, int dialogState)
    {
        onMusicBtn.SetActive(musicState == 1);
        offMusicBtn.SetActive(musicState == 0);
        onSfxBtn.SetActive(sfxState == 1);
        offSfxBtn.SetActive(sfxState == 0);
        onDialog.SetActive(dialogState == 1);
        offDialog.SetActive(dialogState == 0);
    }

    public void GoOffMusic()
    {
        PlayerPrefs.SetInt("StateMusic", 0);
        PlayerPrefs.Save();
        ShowButton(0, PlayerPrefs.GetInt("StateSfx"), PlayerPrefs.GetInt("StateDialog"));
    }

    public void GoOnMusic()
    {
        PlayerPrefs.SetInt("StateMusic", 1);
        PlayerPrefs.Save();
        ShowButton(1, PlayerPrefs.GetInt("StateSfx"), PlayerPrefs.GetInt("StateDialog"));
    }

    public void GoOffSfx()
    {
        PlayerPrefs.SetInt("StateSfx", 0);
        PlayerPrefs.Save();
        ShowButton(PlayerPrefs.GetInt("StateMusic"), 0, PlayerPrefs.GetInt("StateDialog"));
    }

    public void GoOnSfx()
    {
        PlayerPrefs.SetInt("StateSfx", 1);
        PlayerPrefs.Save();
        ShowButton(PlayerPrefs.GetInt("StateMusic"), 1, PlayerPrefs.GetInt("StateDialog"));
    }

    public void GoOffDialog()
    {
        PlayerPrefs.SetInt("StateDialog", 0);
        PlayerPrefs.Save();
        ShowButton(PlayerPrefs.GetInt("StateMusic"), PlayerPrefs.GetInt("StateSfx"), 0);
    }

    public void GoOnDialog()
    {
        PlayerPrefs.SetInt("StateDialog", 1);
        PlayerPrefs.Save();
        ShowButton(PlayerPrefs.GetInt("StateMusic"), PlayerPrefs.GetInt("StateSfx"), 1);
    }
}
