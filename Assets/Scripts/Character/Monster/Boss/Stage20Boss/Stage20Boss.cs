using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage20Boss : Monster
{
    public GameObject spear;
    public Transform aim;
    void Start()
    {
        maxHp = 200;
        hp = 200;
        damage = 30;
        attackSpeed = 5f;
        skillSpeed = 1f;
        maxSpeed = 0.2f;
        speed = maxSpeed;

        SetComponent();

        isCastleAttack = false;

        deathCount = 1;
    }
    public override void Attack()
    {
        GameObject GO = Instantiate(spear);
        GO.transform.position = aim.position;
        GO.GetComponent<CentaurSpear>().isAttack = "Monster";
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
        GameObject GO = Instantiate(spear);
        GO.transform.position = aim.position;
        GO.GetComponent<CentaurSpear>().isAttack = "Castle";
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
