using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareResurrected : Unit
{
    //레어 등급 부활자

    int deathCount;
    void Start()
    {
        deathCount = 0;
        maxHp = 10;
        hp = 10;
        damage = 3;
        attackSpeed = 2f;
        maxSpeed = 2;
        speed = maxSpeed;
        SetComponent();
    }

    private void Update()
    {
        move();
    }

    public override void Death()
    {
        if(deathCount == 0)
        {
            hp = 10;
            damage = 5;
            deathCount++;
        }
        else base.Death();
    }

    public override void Attack()
    {
        monster.Hp = damage;
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
        }
    }
    private void OnTriggerExit2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            speed = maxSpeed;
        }
    }
}
