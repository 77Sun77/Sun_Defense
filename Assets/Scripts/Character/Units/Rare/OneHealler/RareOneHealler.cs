using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareOneHealler : Unit
{
    //레어 등급 힐러
    public GameObject healEffect;
    List<Unit> units = new List<Unit>();
    void Start()
    {
        maxHp = 15;
        hp = 15;
        damage = 0;
        attackSpeed = 5f;
        skillSpeed = 1f;
        maxSpeed = 1;
        speed = maxSpeed;
        SetComponent();
        StartCoroutine(newHealCoolTime());
    }

    private void Update()
    {
        move();

        GameObject[] unit = GameObject.FindGameObjectsWithTag("Unit");
        SetUnits(unit);


    }

    void SetUnits(GameObject[] unit)
    {
        for(int i=0; i< unit.Length; i++)
        {
            units[i] = (Unit) unit[0].GetComponent(typeof(Unit));
        }
    }

    void Healling(int healNumber)
    {
        units[healNumber].hp += 3;
        if(units[healNumber].hp > units[healNumber].maxHp) units[healNumber].hp = units[healNumber].maxHp;
        
    }

    protected IEnumerator newHealCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                int randomNumber = Random.Range(0, units.Count);
                yield return new WaitForSeconds(attackSpeed);
                anim.SetTrigger("isAttack");
                speed = 0;
                if (units.Count != 0)
                {
                    Instantiate(healEffect, units[randomNumber].transform);
                    Healling(randomNumber);
                }
                yield return new WaitForSeconds(skillSpeed);
                speed = maxSpeed;
            }
        }
    }


}
