using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage10Boss : Monster
{
    public GameObject attack1, attack2;
    void Start()
    {
        maxHp = 30;
        hp = 30;
        damage = 8;
        attackSpeed = 1f;
        skillSpeed = 0.5f;
        maxSpeed = 0.7f;
        speed = maxSpeed;

        SetComponent();

        isCastleAttack = false;
        deathCount = 1;
    }


    void Update()
    {
        move();
    }

    public override void Attack()
    {
        
        unit.Hit();
        unit.Hp = 9;
        Invoke("attack1False", 0.4f);

    }
    void attack1False()
    {
        attack1.SetActive(false);
    }

    void Attack2()
    {
        attack2.SetActive(true);
    }

    
    public override void CastleAttack()
    {
        castle.Hit();
        castle.hp -= 9;
        Invoke("attack1False", 0.4f);
    }
    protected IEnumerator CastleAttackCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                attack1.SetActive(true);
                anim.SetTrigger("isAttack");
                yield return new WaitForSeconds(skillSpeed);
                CastleAttack();
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }
    IEnumerator newAttackCooltime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            { 
                if (unit.Hp <= 0)
                {
                    enemys.Remove(unit.myCollider);
                    if (enemys.Count == 0)
                    {
                        isAttact = false;
                        break;
                    }
                }
                anim.SetTrigger("isAttack");
                if (unit.Hp > 5)
                {
                    attack1.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    Attack();
                    yield return new WaitForSeconds(2);
                }
                else
                {
                    yield return new WaitForSeconds(0.3f);
                    Attack2();
                    yield return new WaitForSeconds(2);
                }
                
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit" && !isCastleAttack)
        {
            enemys.Add(Unit);
            this.unit = (Unit)enemys[0].GetComponent(typeof(Unit));
            coroutine = newAttackCooltime();
            StartCoroutine(coroutine);
        }

    }
    private void OnTriggerStay2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit" && !isCastleAttack)
        {
            speed = 0;
            anim.SetBool("isWalk", false);
            this.unit = (Unit)enemys[0].GetComponent(typeof(Unit));
        }
        else if (Unit.tag == "Castle")
        {
            speed = 0;
            anim.SetBool("isWalk", false);
        }

        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                enemys.Remove(enemys[index]);
            }
        }

        if (Unit.tag == "Castle" && enemys.Count == 0 && !isCastleAttack)
        {
            isCastleAttack = true;
            this.castle = Unit.GetComponent<Castle>();
            if (coroutine != null) StopCoroutine(coroutine);
            isAttact = false;
            StartCoroutine(CastleAttackCoolTime());
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
