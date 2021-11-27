using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBoss : Monster
{
    public bool isAttack;
    public GameObject skill;
    public Transform aim;
    public bool target;

    int realHp;
    void Start()
    {
        maxHp = 100;
        hp = 100;
        realHp = 100;
        damage = 100;
        attackSpeed = 2f;
        skillSpeed = 0.7f;
        maxSpeed = 0.3f;
        speed = maxSpeed;

        SetComponent();

        isCastleAttack = false;

        deathCount = 1;
        target = false;
    }

    void Update()
    {
        move();
        if(realHp != hp)
        {
            if (target)
            {
                realHp = hp;
                target = false;
            }
            else
            {
                hp = realHp;
                target = false;
            }
        }
    }

    public override void Attack()
    {
        GameObject GO = Instantiate(skill);
        GO.transform.position = aim.position;
    }

    public override void CastleAttack()
    {
        GameObject GO = Instantiate(skill);
        GO.transform.position = aim.position;

    }
    private void OnTriggerEnter2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit" && isCastleAttack == false && isAttack)
        {
            enemys.Add(Unit);
            this.unit = (Unit)enemys[0].GetComponent(typeof(Unit));
            coroutine = attackCoolTime();
            StartCoroutine(coroutine);

        }
    }
    private void OnTriggerStay2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit" && !isCastleAttack && isAttack)
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
        if (Unit.tag == "Unit" && isAttack)
        {
            speed = maxSpeed;
            anim.SetBool("isWalk", true);
        }
    }
}
