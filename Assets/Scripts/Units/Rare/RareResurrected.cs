using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareResurrected : Unit
{
    //���� ��� ��Ȱ��

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
            speed = 0;
            this.monster = (Monster)enemy.GetComponent(typeof(Monster));

            StartCoroutine(attackCoolTime());
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
