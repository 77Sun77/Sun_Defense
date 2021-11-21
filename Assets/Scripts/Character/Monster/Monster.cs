using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    protected Unit unit;
    protected Castle castle;
    protected bool isCastleAttack;
    protected IEnumerator coroutine;
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

    protected IEnumerator CastleAttackCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                anim.SetTrigger("isAttack");
                yield return new WaitForSeconds(skillSpeed);
                CastleAttack();
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }

    public virtual void CastleAttack()
    {

    }
    

    protected void move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public override void Death()
    {
        base.Death();
        if (deathCount == 0) return;
        GameManager.count -= 1;
        deathCount = 0;
    }
}
