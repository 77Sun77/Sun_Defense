using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMonster : Monster
{
    public GameObject aim;
    public GameObject razer;
    void Start()
    {
        maxHp = 8;
        hp = 8;
        damage = 3;
        attackSpeed = 6f;
        skillSpeed = 0.65f;
        maxSpeed = 0.7f;
        speed = maxSpeed;

        SetComponent();

        isCastleAttack = false;
        deathCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public override void Attack()
    {
        GameObject razer = Instantiate(this.razer);
        razer.transform.position = new Vector2(aim.transform.position.x, razer.transform.position.y);
    }

    public override void CastleAttack()
    {
        GameObject razer = Instantiate(this.razer);
        razer.transform.position = new Vector2(aim.transform.position.x, razer.transform.position.y);
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
        else if (Unit.tag == "Castle")
        {
            speed = 0;
            anim.SetBool("isWalk", false);
        }

        if (Unit.tag == "Castle" && enemys.Count == 0 && !isCastleAttack)
        {
            isCastleAttack = true;
            this.castle = Unit.GetComponent<Castle>();
            StopCoroutine(coroutine);
            coroutine = CastleAttackCoolTime();
            StartCoroutine(coroutine);
        }

        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                enemys.Remove(enemys[index]);
            }
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
