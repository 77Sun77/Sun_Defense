using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMonster : Monster
{
    void Start()
    {
        maxHp = 20;
        hp = 20;
        damage = 10;
        attackSpeed = 3f;
        skillSpeed = 1.2f;
        maxSpeed = 0.5f;
        speed = maxSpeed;

        SetComponent();

        isCastleAttack = false;

        deathCount = 1;
    }
    public override void Attack()
    {
        unit.Hit();
        unit.Hp = damage;
    }
    protected IEnumerator attackCoolTime()
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
                effect.UseEffect(1.6f);
                yield return new WaitForSeconds(skillSpeed);
                Attack();
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }

    protected IEnumerator CastleAttackCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                anim.SetTrigger("isAttack");
                effect.UseEffect(1.6f);
                yield return new WaitForSeconds(skillSpeed);
                CastleAttack();
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }
    void Update()
    {
        move();
    }

    public override void CastleAttack()
    {
        castle.Hit();
        castle.hp -= damage;
    }

    private void OnTriggerEnter2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit" && isCastleAttack == false)
        {
            enemys.Add(Unit);
            this.unit = (Unit)enemys[0].GetComponent(typeof(Unit));
            coroutine = attackCoolTime();
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

        if (Unit.tag == "Castle" && enemys.Count == 0 && isCastleAttack == false)
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
