using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : Monster
{
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 5;
        attackSpeed = 2f;
        maxSpeed = 2;
        speed = maxSpeed;
        kind = monsterKinds.Basic;
        
    }

    void Update()
    {
        move();
    }
    public override void Attack()
    {
        unit.Hp = damage;
    }

    private void OnTriggerEnter2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit")
        {
            speed = 0;

            this.unit = (Unit) Unit.GetComponent(typeof(Unit));

            StartCoroutine(attackCoolTime());
        }

    }

    private void OnTriggerExit2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit")
        {
            speed = maxSpeed;
        }
    }
}
