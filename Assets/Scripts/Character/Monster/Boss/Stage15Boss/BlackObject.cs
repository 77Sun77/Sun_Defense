using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackObject : Monster
{
    void Start()
    {
        maxHp = 1;
        hp = 1;
        damage = 100;
        attackSpeed = 2f;
        skillSpeed = 0.8f;
        maxSpeed = 8f;
        speed = maxSpeed;

        SetComponent();

        isCastleAttack = false;

        deathCount = 1;
    }

    private void Update()
    {
        move();
    }
    private void OnTriggerEnter2D(Collider2D Unit)
    {
        if (Unit.tag == "Castle")
        {
            this.castle = Unit.GetComponent<Castle>();
            castle.Hit();
            castle.hp -= damage;
        }
    }
}
