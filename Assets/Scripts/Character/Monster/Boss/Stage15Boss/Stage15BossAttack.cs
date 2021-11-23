using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage15BossAttack : MonoBehaviour
{
    bool isAttack;
    public string Object;
    public Unit unit;
    public Castle castle;
    void Start()
    {
        isAttack = true;
        StartCoroutine(attackCool());
        Destroy(gameObject, 0.6f);
    }

    IEnumerator attackCool()
    {
        yield return new WaitForSeconds(0.3f);
        if(Object == "Unit")
        {
            unit.Hit();
            unit.Hp = 8;
        }
        else if(Object == "Castle")
        {
            castle.Hit();
            castle.hp -= 8;
        }
        
        
    }

    
}
