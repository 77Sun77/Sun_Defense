using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public Unit unit;
    public monsterKinds kind;

    protected IEnumerator attackCoolTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            Attack();
            if (unit.Hp <= 0) break;
        }

    }

    protected void move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
