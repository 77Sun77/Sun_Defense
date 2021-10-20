using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonIceWizard : Unit
{
    //일반 등급 얼음 마법사
    List<Monster> monsterArray = new List<Monster>();
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 2;
        attackSpeed = 3f;
        skillSpeed = 0.9f;
        maxSpeed = 1.2f;
        speed = maxSpeed;
        SetComponent();
    }


    void Update()
    {
        move();
    }

    void Slow()
    {
        foreach (Collider2D monster in enemys)
        {
            this.monster = monster.GetComponent<Monster>();
            this.monster.Hp = damage;
            this.monster.Hit();
            if (this.monster.myState != state.Freeze)
            {
                this.monster.myState = state.Freeze;
                if (this.monster.maxSpeed - 1.5f > 0.7f) this.monster.maxSpeed -= 1.5f;
                else this.monster.maxSpeed = 0.7f;
                if (this.monster.speed != 0) this.monster.speed = this.monster.maxSpeed;
            }
        }

    }
    public override void Attack()
    {
        Slow();
        effect.UseEffect(0.9f);
    }

    IEnumerator NewAttackCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                if (enemys == null)
                {
                    if (enemys.Count == 0)
                    {
                        isAttact = false;
                        break;
                    }
                }
                anim.SetTrigger("isAttack");
                yield return new WaitForSeconds(skillSpeed);
                Attack();
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            enemys.Add(enemy);
            this.monster = (Monster)enemys[0].GetComponent(typeof(Monster));
            StartCoroutine(NewAttackCoolTime());
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
