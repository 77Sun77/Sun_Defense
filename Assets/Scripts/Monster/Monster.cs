using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public Unit unit;

    protected IEnumerator attackCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                
                if (unit.Hp <= 0)
                {
                    enemys.Remove(unit.myCollider);
                    if(enemys.Count == 0)
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
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
