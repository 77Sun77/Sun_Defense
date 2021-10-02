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
            anim.SetTrigger("isAttack");
            yield return new WaitForSeconds(skillSpeed);
            Attack();
            if (monster.Hp <= 0) break;
            yield return new WaitForSeconds(attackSpeed);

        }

    }
    protected void move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    
}
