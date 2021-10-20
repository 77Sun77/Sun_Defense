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
        skillSpeed = 0.7f;
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
            anim.SetBool("isRevival", true);
        }
        else base.Death();
    }

    public override void Attack()
    {
        monster.Hit();
        monster.Hp = damage;
    }

    protected IEnumerator newAttackCoolTime()
    {
        while (true)
        {
            if (monster.Hp <= 0)
            {
                enemys.Remove(monster.myCollider);
                if (enemys.Count == 0)
                {
                    isAttact = false;
                    break;
                }
            }
            anim.SetTrigger("isAttack");
            effect.UseEffect(1.3f);
            yield return new WaitForSeconds(skillSpeed);
            Attack();
            yield return new WaitForSeconds(attackSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            enemys.Add(enemy);
            this.monster = (Monster)enemys[0].GetComponent(typeof(Monster));
            StartCoroutine(newAttackCoolTime());
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
