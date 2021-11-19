using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryEngel : Unit
{
    // 전설 등급 천사
    public GameObject healEffect;
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 0;
        attackSpeed = 5f;
        skillSpeed = 1f;
        maxSpeed = 0.3f;
        speed = maxSpeed;
        SetComponent();
        StartCoroutine(newHealCoolTime());
    }

    void Update()
    {
        move();
    }
    public override void Attack()
    {
        healEffect.SetActive(true);
    }
    protected IEnumerator newHealCoolTime()
    { 
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            speed = 0;
            Attack();
            yield return new WaitForSeconds(skillSpeed);
            speed = maxSpeed;
        }
        
    }
}
