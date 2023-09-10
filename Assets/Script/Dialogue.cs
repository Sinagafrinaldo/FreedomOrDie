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
    public float wordSpeed = 0.1f;

    public GameObject contButton;

    private bool hasInteracted;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        contButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            dialoguePanel.SetActive(true);
            UIpanel.SetActive(false);

            // Memeriksa apakah ada audio yang tersedia dan belum diputar
            if (dialogueAudio.Length > index && dialogueAudio[index] != null)
            {
                audioSource.clip = dialogueAudio[index];
                audioSource.Play();
            }

            StartCoroutine(Typing());
            Time.timeScale = 0f;
        }
    }

    IEnumerator Typing()
    {
        dialogueText.text = "";
        bool fullTextDisplayed = false; // Apakah seluruh teks sudah ditampilkan

        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                fullTextDisplayed = true;
                dialogueText.text = dialogue[index]; // Tampilkan seluruh teks
                break;
            }
        }

        contButton.SetActive(true);
        hasInteracted = true;

        // Tampilkan seluruh teks jika belum ditampilkan
        if (!fullTextDisplayed)
        {
            dialogueText.text = dialogue[index];
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;

            // Memeriksa apakah ada audio yang tersedia dan belum diputar
            if (dialogueAudio.Length > index && dialogueAudio[index] != null)
            {
                audioSource.clip = dialogueAudio[index];
                audioSource.Play();
            }

            StartCoroutine(Typing());
        }
        else
        {
            dialoguePanel.SetActive(false);
            hasInteracted = false;
            gameObject.SetActive(false);

            if (gameObject.CompareTag("FirstTrigger"))
            {
                UIpanel.SetActive(true);
                gameObject.SetActive(false);
            }

            if (gameObject.CompareTag("SecondTrigger"))
            {
                GameObject firstTrigger = GameObject.FindGameObjectWithTag("FirstTrigger");

                if (firstTrigger != null)
                    firstTrigger.SetActive(true);
            }

            Time.timeScale = 1f;
            PlayerMovement.MoveRight = false;
            PlayerMovement.MoveLeft = false;
        }
    }
}
