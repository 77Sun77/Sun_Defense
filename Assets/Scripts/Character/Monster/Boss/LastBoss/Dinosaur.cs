using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : Monster
{
    public GameObject lastBoss;
    void Start()
    {
        maxHp = 40;
        hp = 40;
        damage = 8;
        maxSpeed = 0.2f;
        speed = maxSpeed;
        attackSpeed = 4f;
        skillSpeed = 1.5f;
        SetComponent();


        deathCount = 1;
    }

    void Update()
    {
        move();
    }
    public override void Attack()
    {
        effect.GetComponent<DinosaurFireBall>().unitKind = "Unit";
        BoxCollider2D myCollider = effect.GetComponent<BoxCollider2D>();
        myCollider.enabled = false;
        effect.UseEffect(0.9f);
    }
    public override void CastleAttack()
    {
        effect.GetComponent<DinosaurFireBall>().unitKind = "Castle";
        BoxCollider2D myCollider = effect.GetComponent<BoxCollider2D>();
        myCollider.enabled = false;
        effect.UseEffect(0.9f);
    }

    public override void Death()
    {
        GameObject GO = Instantiate(lastBoss);
        GO.transform.position = new Vector2(transform.position.x-0.49f , -0.18f);
        base.Death();
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
