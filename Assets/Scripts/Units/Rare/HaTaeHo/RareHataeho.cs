using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareHataeho : Unit
{
    // 레어 등급 하태호
    void Start()
    {
        maxHp = 12;
        hp = 12;
        damage = 5;
        attackSpeed = 1.5f;
        skillSpeed = 1.3f;
        maxSpeed = 2f;
        speed = maxSpeed;
        SetComponent();
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
