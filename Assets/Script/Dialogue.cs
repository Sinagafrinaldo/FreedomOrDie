using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject UIpanel;
    public Text dialogueText;
    public string[] dialogue;
    public AudioClip[] dialogueAudio;
    private int index;
    public float wordSpeed;
    public GameObject contButton;

    private bool hasInteracted;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            dialoguePanel.SetActive(true);
            UIpanel.SetActive(false);
            StartCoroutine(Typing());
            Time.timeScale = 0f;
        }
    }

    IEnumerator Typing()
    {
        dialogueText.text = "";
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        contButton.SetActive(true);

        if (dialogueAudio.Length > index && dialogueAudio[index] != null)
        {
            audioSource.clip = dialogueAudio[index];
            audioSource.Play();
        }

        hasInteracted = true;
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            StartCoroutine(Typing());
        }
        else
        {
            dialoguePanel.SetActive(false);
            hasInteracted = false;
            gameObject.SetActive(false);

            // Jika ini adalah trigger pertama
            if (gameObject.CompareTag("FirstTrigger"))
            {
                // Aktifkan kembali UI panel trigger pertama
                UIpanel.SetActive(true);

                // Nonaktifkan trigger pertama agar tidak bisa dipicu lagi
                gameObject.SetActive(false);
            }

            // Jika ini adalah trigger kedua
            if (gameObject.CompareTag("SecondTrigger"))
            {
                // Cari objek trigger pertama berdasarkan tag
                GameObject firstTrigger = GameObject.FindGameObjectWithTag("FirstTrigger");

                // Aktifkan kembali trigger pertama
                if (firstTrigger != null)
                    firstTrigger.SetActive(true);
            }

            Time.timeScale = 1f;
            PlayerMovement.MoveRight = false;
            PlayerMovement.MoveLeft = false;
        }
    }
}
