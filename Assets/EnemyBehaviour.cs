using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float Hp;
    public float maxHp = 5;
    void Start()
    {
        Hp = maxHp;
    }

    // Update is called once per frame
    public void TakeHit (float damage){
        Hp -= damage;
        if (Hp <=0){
            Destroy(gameObject);
        }
    }
}
