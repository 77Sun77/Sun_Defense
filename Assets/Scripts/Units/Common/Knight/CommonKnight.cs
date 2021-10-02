using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonKnight : Unit
{
    [SerializeField]
    Effect effect;
    //처음 지급 기사
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 4;
        attackSpeed = 2f;
        skillSpeed = 0.9f;
        maxSpeed = 1.5f;
        speed = maxSpeed;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        move();
    }

    public override void Attack()
    {
        StartCoroutine(monster.Hit());
        monster.Hp = damage;
        effect.UseEffect(0.5f);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            speed = 0;
            anim.SetBool("isWalk", false);
            this.monster = (Monster)enemy.GetComponent(typeof(Monster));

            StartCoroutine(attackCoolTime());
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
