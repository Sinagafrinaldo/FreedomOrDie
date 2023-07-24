using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSc : MonoBehaviour
{
    public GameObject Objective;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Hanya berinteraksi jika belum ditampilkan sebelumnya
        {
            StartCoroutine(ActivateObjectiveForDuration(10f)); // Mengaktifkan Objective selama 10 detik

        }
    }

    IEnumerator ActivateObjectiveForDuration(float duration)
    {
        Objective.SetActive(true); // Mengaktifkan Objective

        yield return new WaitForSeconds(duration); // Menunggu selama durasi yang ditentukan

        Objective.SetActive(false); // Menonaktifkan Objective setelah durasi selesai
        Destroy(gameObject);
    }
}
