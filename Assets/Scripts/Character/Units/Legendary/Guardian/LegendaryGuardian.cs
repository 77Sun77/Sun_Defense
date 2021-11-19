using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryGuardian : Unit
{
    // 전설 등급 수호자
    void Start()
    {
        maxHp = 40;
        hp = 40;
        maxSpeed = 0.5f;
        speed = maxSpeed;
        SetComponent();
    }


    void Update()
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
