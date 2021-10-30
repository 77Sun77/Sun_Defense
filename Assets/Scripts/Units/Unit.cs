using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Character
{
    
    protected Monster monster;

    protected IEnumerator attackCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                if (monster.Hp <= 0)
                {
                    enemys.Remove(monster.myCollider);
                    if (enemys.Count == 0)
                    {
                        isAttact = false;
                        break;
                    }
                }
                anim.SetTrigger("isAttack");
                yield return new WaitForSeconds(skillSpeed);
                Attack();
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }
    protected void move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
