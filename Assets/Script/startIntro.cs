using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startIntro : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator camAnim;
    public GameObject buttons;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.ms = 0;
            buttons.SetActive(false);
            camAnim.SetBool("cutScene1", true);
            Invoke(nameof(StopCutScene), 2f);
        }
    }
    void StopCutScene()
    {
        PlayerMovement.MoveRight = false;
        PlayerMovement.ms = 5;
        buttons.SetActive(true);
        camAnim.SetBool("cutScene1", false);
        Destroy(gameObject);
    }
}
