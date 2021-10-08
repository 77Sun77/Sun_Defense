using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBeggarBoy : Unit
{
    // 가난한 소년
    void Start()
    {
        maxHp = 6;
        hp = 6;
        damage = 2;
        attackSpeed = 0.3f;
        skillSpeed = 0.3f;
        maxSpeed = 3f;
        speed = maxSpeed;
        SetComponent();
    }


    void Update()
    {
        move();
    }

    public override void Attack()
    {
        StartCoroutine(monster.Hit());
        monster.Hp = damage;
        effect.UseEffect(0.2f);
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

        foreach (Collider2D monsters in enemys)
        {
            if (monsters == null)
            {
                enemys.Remove(monsters);
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
