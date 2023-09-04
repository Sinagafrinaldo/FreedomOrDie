using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    public GameObject healthPrefab; // Assign your health prefab here
    private bool hasSpawnedHealth = false;
    public GameObject EndGame;
    public int targetTotal;
    private bool hasShowObjective = false;
    private bool hasShowObjective2 = false;
    public GameObject Objective;
    public GameObject Objective2;

    void Update()
    {
        if (hasSpawnedHealth==false && enemyHealth.enemiesKilled % 5 == 0 && enemyHealth.enemiesKilled > 0)
        {
            // Spawn the health object
            Instantiate(healthPrefab, transform.position, Quaternion.identity);
            hasSpawnedHealth = true;
        }else if (enemyHealth.enemiesKilled % 5 != 0 ){
            hasSpawnedHealth = false;
        }

        if ((enemyHealth.enemiesKilled == targetTotal/2)  && hasShowObjective == false){
         
            StartCoroutine(ActivateObjectiveForDuration(5f));
            hasShowObjective = true;
        }
        // Debug.Log(enemyHealth.enemiesKilled);
        if ((enemyHealth.enemiesKilled == targetTotal-2) && hasShowObjective2 == false){
         
            StartCoroutine(Activate2ndObjectiveForDuration(2f));
            hasShowObjective2 = true;
        }

        if (enemyHealth.enemiesKilled >= targetTotal){
            EndGame.SetActive(true);
        }

    }
        

        public IEnumerator ActivateObjectiveForDuration(float duration)
        {
        Objective.SetActive(true); // Mengaktifkan Objective

        yield return new WaitForSeconds(duration); // Menunggu selama durasi yang ditentukan

        Objective.SetActive(false); // Menonaktifkan Objective setelah durasi selesai
        // Destroy(gameObject);
        }

         public IEnumerator Activate2ndObjectiveForDuration(float duration)
        {
        Objective2.SetActive(true); // Mengaktifkan Objective

        yield return new WaitForSeconds(duration); // Menunggu selama durasi yang ditentukan

        Objective2.SetActive(false); // Menonaktifkan Objective setelah durasi selesai
        // Destroy(gameObject);
        }
}