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
        skillSpeed = 0.9f;
        maxSpeed = 1.5f;
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
        effect.UseEffect(0.5f);
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
