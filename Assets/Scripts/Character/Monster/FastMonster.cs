using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMonster : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 5;
        hp = 5;
        damage = 10;
        maxSpeed = 5f;
        speed = maxSpeed;

        SetComponent();


        deathCount = 1;

        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Castle")
        {
            castle = collision.GetComponent<Castle>();
            castle.Hit();
            castle.hp -= damage;
        }
    }
}
