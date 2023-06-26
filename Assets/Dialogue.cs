using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public AudioClip[] dialogueAudio; // Array untuk menyimpan audio untuk setiap baris dialog
    private int index;
    public float wordSpeed;
    private bool playerIsClose;
    public GameObject contButton;

    private bool hasInteracted; // Flag untuk menandai apakah dialog sudah ditampilkan

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Menambahkan komponen AudioSource
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted) // Hanya berinteraksi jika belum ditampilkan sebelumnya
        {
            playerIsClose = true;
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            if (!hasInteracted) // Jika belum ditampilkan sebelumnya, maka tutup panel
                dialoguePanel.SetActive(false);
        }
    }

    IEnumerator Typing()
    {
        dialogueText.text = ""; // Reset teks dialog
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        contButton.SetActive(true);

        // Memeriksa apakah ada audio untuk baris dialog saat ini
        if (dialogueAudio.Length > index && dialogueAudio[index] != null)
        {
            audioSource.clip = dialogueAudio[index];
            audioSource.Play();
        }

        hasInteracted = true; // Menandai bahwa dialog sudah ditampilkan
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
            hasInteracted = false; // Reset flag interaksi
            gameObject.SetActive(false); // Menonaktifkan objek setelah dialog selesai
        }
    }
}
