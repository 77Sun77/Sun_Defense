using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSuperMan : Unit
{
    //일반 등급 슈퍼맨
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 2;
        attackSpeed = 1.5f;
        skillSpeed = 0.6f;
        maxSpeed = 1.5f;
        speed = maxSpeed;
        SetComponent();
        StartCoroutine(DamageUp());
    }


    void Update()
    {
        move();
    }

    public override void Attack()
    {
        monster.Hit();
        monster.Hp = damage;
    }
    protected IEnumerator newAttackCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
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
                effect.UseEffect(1f);
                yield return new WaitForSeconds(skillSpeed);
                Attack();
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }
    IEnumerator DamageUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            damage++;
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
