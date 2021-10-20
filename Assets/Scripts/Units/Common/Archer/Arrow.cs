using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Monster monster;
    int damage=3;
    
    void Update()
    {
        transform.Translate(Vector2.right * 2.5f * Time.deltaTime);
    }

    public void Attack()
    {
        monster.Hit();
        monster.Hp = damage;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.tag == "Monster")
        {
            monster = this.monster = (Monster)enemy.GetComponent(typeof(Monster));
            Attack();
        }
    }
}
