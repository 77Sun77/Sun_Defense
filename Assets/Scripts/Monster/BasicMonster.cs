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
        skillSpeed = 0.9f;
        maxSpeed = 2;
        speed = maxSpeed;

        SetComponent();
    }

    void Update()
    {
        move();
    }
    public override void Attack()
    {
        unit.Hit();
        unit.Hp = damage;
        effect.UseEffect(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit")
        {
            enemys.Add(Unit);
            this.unit = (Unit)enemys[0].GetComponent(typeof(Unit));
            StartCoroutine(attackCoolTime());
        }

    }
    private void OnTriggerStay2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit")
        {
            speed = 0;
            anim.SetBool("isWalk", false);
            this.unit = (Unit)enemys[0].GetComponent(typeof(Unit));
        } 

        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                enemys.Remove(enemys[index]);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit")
        {
            speed = maxSpeed;
            anim.SetBool("isWalk", true);
        }
    }
}
