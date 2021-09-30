using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonKnight : Unit
{
    
    void Start()
    {
        maxHp = 20;
        hp = 20;
        damage = 4;
        attackSpeed = 2f;
        maxSpeed = 2;
        speed = maxSpeed;
    }

    
    void Update()
    {
        move();
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            speed = 0;
            this.monster = enemy.GetComponent<Monster>();
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
