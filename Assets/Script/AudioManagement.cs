using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioSource musicAudioSource;
    private int prefsMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("StateMusic"))
        {
            PlayerPrefs.SetInt("StateMusic", 1);
        }
        prefsMusic = PlayerPrefs.GetInt("StateMusic");
        PlayMusic(prefsMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
        int currentPrefsMusic = PlayerPrefs.GetInt("StateMusic");
        if (currentPrefsMusic != prefsMusic)
        {
            prefsMusic = currentPrefsMusic;
            PlayMusic(prefsMusic);
        }
        
    }

    public void PlayMusic(int state)
    {
        if (state == 1)
        {
            musicAudioSource.Play(); // Play the music
        }
        else
        {
            musicAudioSource.Stop(); // Stop the music
        }
    }

    
}
