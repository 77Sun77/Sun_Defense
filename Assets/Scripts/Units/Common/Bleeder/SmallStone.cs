using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallStone : MonoBehaviour
{
    List<Monster> monster = new List<Monster>();
    int damage = 2;

    void Start()
    {
        Rigidbody2D stoneRigid = GetComponent<Rigidbody2D>();
        stoneRigid.velocity = new Vector2(0, 3);
    }
    void Update()
    {
        transform.Translate(Vector2.right * 3f * Time.deltaTime);
    }

    public void Attack()
    {
        monster[0].Hit();
        monster[0].Hp = damage;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            monster.Add((Monster)enemy.GetComponent(typeof(Monster)));
            Attack();
        }
        if(enemy.tag == "Ground") Destroy(gameObject);
    }

}
