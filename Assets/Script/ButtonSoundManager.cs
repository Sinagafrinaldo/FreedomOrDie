using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioClip buttonClickSound; // Suara yang akan diputar saat tombol diklik

    private void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>(); // Temukan semua komponen Button di scene

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayButtonClickSound()); // Tambahkan listener untuk setiap tombol
        }
    }

    private void PlayButtonClickSound()
    {
        if (!PlayerPrefs.HasKey("StateSfx"))
        {
            PlayerPrefs.SetInt("StateSfx", 1);
        }

        int statesFx = PlayerPrefs.GetInt("StateSfx");

        if (statesFx == 1){
        AudioSource.PlayClipAtPoint(buttonClickSound, Camera.main.transform.position);
        }
    }
}
