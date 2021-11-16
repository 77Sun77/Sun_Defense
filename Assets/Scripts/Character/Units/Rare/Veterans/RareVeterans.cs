using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareVeterans : Unit
{
    // 레어 등급 용사

    public GameObject lightSword;
    public Transform aim;
    void Start()
    {
        maxHp = 15;
        hp = 15;
        damage = 10;
        attackSpeed = 4f;
        skillSpeed = 1f;
        maxSpeed = 0.5f;
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
        GameObject sword = Instantiate(lightSword);
        sword.transform.position = aim.position;


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
