using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryElf : Unit
{
    // 전설 등급 엘프

    public GameObject arrow;
    public GameObject aim;
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 3;
        attackSpeed = 6f;
        skillSpeed = 1.6f;
        maxSpeed = 1f;
        speed = maxSpeed;
        SetComponent();
    }


    void Update()
    {
        move();
    }

    public override void Attack()
    {
        GameObject attack = Instantiate(arrow);
        attack.transform.position = aim.transform.position;
        Destroy(attack, 2f);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            enemys.Add(enemy);
            this.monster = (Monster)enemys[0].GetComponent(typeof(Monster));
            StartCoroutine(attackCoolTime());
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
