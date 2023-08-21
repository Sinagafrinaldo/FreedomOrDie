using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    public GameObject bintang0;
    public GameObject bintang1;
    public GameObject bintang2;
    public GameObject bintang3;
    public int levelNum;

    void Start()
    {
        // Ubah ini untuk mengambil SaveStar berdasarkan levelNum
        int currentStars = PlayerPrefs.GetInt("SaveStar" + levelNum, 0);

        // Jika currentStars belum ada (null), atur ke nilai default 0
        if (!PlayerPrefs.HasKey("SaveStar" + levelNum))
        {
            currentStars = 0;
        }

        // Menampilkan bintang sesuai jumlah currentStars
        ShowStars(currentStars);
    }

    // Metode untuk menampilkan bintang sesuai jumlah
    void ShowStars(int stars)
    {
        bintang0.SetActive(stars == 0);
        bintang1.SetActive(stars == 1);
        bintang2.SetActive(stars == 2);
        bintang3.SetActive(stars == 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
