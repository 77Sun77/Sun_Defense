using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Character
{
    
    protected Monster monster;
    protected IEnumerator attackCoolTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            Attack();
            if (monster.Hp <= 0) break;
        }
        
    }
    protected void move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    
}
