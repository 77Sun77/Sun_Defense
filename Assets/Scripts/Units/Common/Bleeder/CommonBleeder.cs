using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBleeder : Unit
{
    //일반 등급 도련님
    public GameObject stone;
    public Transform stoneAim;

    void Start()
    {
        maxHp = 5;
        hp = 6;
        damage = 2;
        attackSpeed = 1.5f;
        skillSpeed = 0.5f;
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
        GameObject summonsStone = Instantiate(stone);
        summonsStone.transform.position = new Vector2(stoneAim.position.x + 1.45f, -0.63f);
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
