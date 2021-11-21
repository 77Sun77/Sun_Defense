using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : Monster
{
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 4;
        attackSpeed = 2f;
        skillSpeed = 0.9f;
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
        unit.Hp = damage;
        effect.UseEffect(0.5f);
    }

    public override void CastleAttack()
    {
        castle.Hit();
        castle.hp -= damage;
        effect.UseEffect(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit" && !isCastleAttack)
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
        else if(Unit.tag == "Castle")
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
            StopCoroutine(coroutine);
            coroutine = CastleAttackCoolTime();
            StartCoroutine(coroutine);
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
