using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject cutsceneObject;
    public Transform enemyLocation;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(TriggerCutscene());
        }
    }

    IEnumerator TriggerCutscene()
    {
        // Nonaktifkan karakter atau komponen yang terkait dengan pergerakan karakter
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().enabled = false;
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        playerRb.velocity = Vector2.zero;

        // Aktifkan cutscene dan setel posisi musuh
        cutsceneObject.SetActive(true);
        cutsceneObject.transform.position = enemyLocation.position;

        // Tunggu beberapa waktu agar pemain dapat melihat cutscene
        yield return new WaitForSeconds(2f);

        // Nonaktifkan cutscene dan aktifkan kembali kontrol karakter
        cutsceneObject.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
