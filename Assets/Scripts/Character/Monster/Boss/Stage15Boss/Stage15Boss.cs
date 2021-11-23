using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage15Boss : Monster
{
    public GameObject skill;
    bool isCastle, isMove;
    void Start()
    {
        maxHp = 50;
        hp = 50;
        damage = 8;
        maxSpeed = 0.42f;
        speed = maxSpeed;

        SetComponent();

        isCastleAttack = false;
        isCastle = false;
        isMove = false;
        deathCount = 1;
        StartCoroutine(moveActive());
    }

    IEnumerator moveActive()
    {
        yield return new WaitForSeconds(2.6f);
        isMove = true;
    }
    void Update()
    {
        if(isMove) move();

    }

    public override void Attack()
    {
        for(int i=0; i< enemys.Count; i++)
        {
            GameObject effect = Instantiate(skill);
            Stage15BossAttack attack = effect.GetComponent<Stage15BossAttack>();
            attack.Object = "Unit";
            attack.unit = (Unit)enemys[i].GetComponent(typeof(Unit));
            skill.transform.position = new Vector2(enemys[i].transform.position.x, skill.transform.position.y);
        }
    }
    public override void CastleAttack()
    {
        GameObject effect = Instantiate(skill);
        Stage15BossAttack attack = effect.GetComponent<Stage15BossAttack>();
        attack.Object = "Castle";
        attack.castle = (Castle)castle.GetComponent(typeof(Castle));
        effect.transform.position = new Vector2(castle.transform.position.x, skill.transform.position.y);
    }
    IEnumerator newAttackCooltime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                if(enemys.Count != 0)
                {
                    if (unit.Hp <= 0)
                    {
                        enemys.Remove(unit.myCollider);
                        if (enemys.Count == 0 && isCastle == false)
                        {
                            isAttact = false;
                            break;
                        }
                    }
                } 
                yield return new WaitForSeconds(0.5f);
                if (enemys.Count != 0) Attack();
                if (isCastle) CastleAttack();
                yield return new WaitForSeconds(2.4f);
            }

        }
    }
    
    private void OnTriggerEnter2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit")
        {
            enemys.Add(Unit);
            this.unit = (Unit)enemys[0].GetComponent(typeof(Unit));
            coroutine = newAttackCooltime();
            StartCoroutine(coroutine);
        }

    }
    private void OnTriggerStay2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit" && !isCastleAttack)
        {
            speed = 0;
            this.unit = (Unit)enemys[0].GetComponent(typeof(Unit));
        }
        else if (Unit.tag == "Castle")
        {
            speed = 0;
        }

        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                enemys.Remove(enemys[index]);
            }
        }

        if (Unit.tag == "Castle" && enemys.Count == 0 && !isCastleAttack)
        {
            this.castle = Unit.GetComponent<Castle>();
            if (coroutine == null) StartCoroutine(newAttackCooltime());
            isCastleAttack = true;
            isCastle = true;
        }
    }
    private void OnTriggerExit2D(Collider2D Unit)
    {
        if (Unit.tag == "Unit")
        {
            speed = maxSpeed;
        }
    }
}
