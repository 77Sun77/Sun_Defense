using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonNinja : Unit
{
    //일반 등급 닌자
    public GameObject shuriken;
    public Transform shurikenAim;

    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 3;
        attackSpeed = 1f;
        skillSpeed = 0.5f;
        maxSpeed = 2.5f;
        speed = maxSpeed;
        SetComponent();
    }


    void Update()
    {
        move();
    }

    public override void Attack()
    {
        GameObject summonsArrow = Instantiate(shuriken);
        summonsArrow.transform.position = shurikenAim.position;
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
