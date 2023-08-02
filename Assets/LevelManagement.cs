using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bintang0;
    public GameObject bintang1;
    public GameObject bintang2;
    public GameObject bintang3;
    void Start()
    {
        int currentStars = PlayerPrefs.GetInt("SaveStar", 0);
        if (currentStars == 0)
        {
            bintang0.SetActive(true);
            bintang1.SetActive(false);
            bintang2.SetActive(false);
            bintang3.SetActive(false);
        }
        else if (currentStars == 1)
        {
            bintang0.SetActive(false);
            bintang1.SetActive(true);
            bintang2.SetActive(false);
            bintang3.SetActive(false);
        }
        else if (currentStars == 2)
        {
            bintang0.SetActive(false);
            bintang1.SetActive(false);
            bintang2.SetActive(true);
            bintang3.SetActive(false);
        }
        else if (currentStars == 3)
        {
            bintang0.SetActive(false);
            bintang1.SetActive(false);
            bintang2.SetActive(false);
            bintang3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
