using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage25Boss : Monster
{
    GameObject[] units = new GameObject[100];
    List<GameObject> units2;
    void Start()
    {
        maxHp = 50;
        hp = 50;
        damage = 30;
        attackSpeed = 8f;
        skillSpeed = 1f;
        maxSpeed = 0.1f;
        speed = maxSpeed;

        SetComponent();

        isCastleAttack = false;

        deathCount = 1;


        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }

    public override void Attack()
    {
        if(GameObject.FindGameObjectsWithTag("Unit").Length != 0)
        {
            units = GameObject.FindGameObjectsWithTag("Unit");

            for (int i = 0; i <GameObject.FindGameObjectsWithTag("Unit").Length; i++)
            {
                unit = (Unit)units[i].GetComponent(typeof(Unit));
                unit.Hit();
                unit.Hp = damage;
            }
        }
        
    }
    
    IEnumerator attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            speed = 0;
            anim.SetTrigger("isAttack");
            yield return new WaitForSeconds(skillSpeed);
            Attack();
            speed = maxSpeed;
        }

    }

    IEnumerator castleAttack()
    {
        speed = 0;
        anim.SetTrigger("isAttack");
        yield return new WaitForSeconds(skillSpeed);
        castle.Hit();
        castle.hp -= damage;
        effect.UseEffect(3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Castle")
        {
            castle = (Castle)collision.GetComponent(typeof(Castle));
            StopAllCoroutines();
            StartCoroutine(castleAttack());
        }
    }
}
