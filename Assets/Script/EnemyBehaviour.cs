using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
 
    public float Hp;
    public float maxHp = 5;
    void Start()
    {
        Hp = maxHp;
    }

    public void TakeHit (float damage){
        Hp -= damage;
        if (Hp <=0){
            Destroy(gameObject);
        }
    }
}
