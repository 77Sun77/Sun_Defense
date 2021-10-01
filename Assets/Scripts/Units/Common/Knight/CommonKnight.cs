using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonKnight : Unit
{
    //처음 지급 기사
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 4;
        attackSpeed = 2f;
        maxSpeed = 2;
        speed = maxSpeed;
    }

    
    void Update()
    {
        move();
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
