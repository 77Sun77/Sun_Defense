using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonArcher : Unit
{
    //처음 지급 궁수
    public GameObject arrow;
    public Transform arrowAim;

    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 3;
        attackSpeed = 2f;
        skillSpeed = 0.6f;
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
        GameObject summonsArrow = Instantiate(arrow);
        summonsArrow.transform.position = new Vector2(arrowAim.position.x + 1.45f, -0.63f);
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

        foreach (Collider2D monsters in enemys)
        {
            if (monsters == null)
            {
                enemys.Remove(monsters);
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
