using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareOneHealler : Unit
{
    //레어 등급 힐러
    public GameObject healEffect;
    GameObject[] unit;
    List<Unit> units = new List<Unit>();
    int randomNumber;
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 0;
        attackSpeed = 5f;
        skillSpeed = 1f;
        maxSpeed = 0.5f;
        speed = maxSpeed;
        SetComponent();
        StartCoroutine(newHealCoolTime());
    }

    private void Update()
    {
        move();
        unit = GameObject.FindGameObjectsWithTag("Unit");
        SetUnits(unit);


    }

    void SetUnits(GameObject[] unit)
    {
        units.RemoveRange(0, units.Count);
        for(int i=0; i< unit.Length; i++)
        {
            units.Add((Unit) unit[i].GetComponent(typeof(Unit)));
        }
    }

    void Healling(int healNumber)
    {
        units[healNumber].hp += 6;
        if(units[healNumber].hp > units[healNumber].maxHp) units[healNumber].hp = units[healNumber].maxHp;
    }

    protected IEnumerator newHealCoolTime()
    {
        if (!isAttact)
        {
            isAttact = true;
            while (true)
            {
                if (unit != null)
                {
                    randomNumber = Random.Range(0, unit.Length);
                }
                yield return new WaitForSeconds(attackSpeed);
                anim.SetBool("isWalk", false);
                anim.SetTrigger("isAttack");
                speed = 0;
                if (unit.Length != 0)
                {
                    Destroy(Instantiate(healEffect, units[randomNumber].transform), 3f);
                    Healling(randomNumber);
                }
                yield return new WaitForSeconds(skillSpeed);
                anim.SetBool("isWalk", true);
                speed = maxSpeed;
            }
        }
    }


}
