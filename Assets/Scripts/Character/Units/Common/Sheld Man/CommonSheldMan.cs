using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSheldMan : Unit
{
    //일반 등급 돌격병

    int deathCount;
    void Start()
    {
        maxHp = 15;
        hp = 15;
        maxSpeed = 0.8f;
        speed = maxSpeed;
        SetComponent();
    }

    private void Update()
    {
        move();
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            enemys.Add(enemy);
        }

    }
    private void OnTriggerStay2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            speed = 0;
            anim.SetBool("isWalk", false);        
        }

        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                enemys.Remove(enemys[index]);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            speed = maxSpeed;
            anim.SetBool("isWalk", true);
        }
    }
}
