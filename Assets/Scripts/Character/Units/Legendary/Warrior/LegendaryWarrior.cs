using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryWarrior : Unit
{
    // 전설 등급 전사
    void Start()
    {
        maxHp = 20;
        hp = 20;
        damage = 9;
        attackSpeed = 3f;
        skillSpeed = 0.8f;
        maxSpeed = 0.5f;
        speed = maxSpeed;
        SetComponent();
    }

    public override void Attack()
    {
        effect.UseEffect(0.7f);
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
            this.monster = (Monster)enemys[0].GetComponent(typeof(Monster));
            StartCoroutine(attackCoolTime());
        }

    }
    private void OnTriggerStay2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            speed = 0;
            anim.SetBool("isWalk", false);
            this.monster = (Monster)enemys[0].GetComponent(typeof(Monster));
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
