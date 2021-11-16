using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareKimJeongUn : Unit
{
    // 레어 등급 김정운(파동술사)
    public GameObject waveBullet;
    public Transform aim;
    void Start()
    {
        maxHp = 15;
        hp = 15;
        damage = 0;
        attackSpeed = 3f;
        skillSpeed = 1.7f;
        maxSpeed = 1f;
        speed = maxSpeed;
        SetComponent();
    }

    void Update()
    {
        move();
    }

    void Attack()
    {
        GameObject waveBullet = Instantiate(this.waveBullet);
        waveBullet.transform.position = aim.position;
        waveBullet.GetComponent<WaveBullet>().waveMan = gameObject;
    }

    protected IEnumerator newAttackCoolTime()
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

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            enemys.Add(enemy);
            this.monster = (Monster)enemys[0].GetComponent(typeof(Monster));
            StartCoroutine(newAttackCoolTime());
        }

    }
    private void OnTriggerStay2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            speed = 0;
            anim.SetBool("isWalk", false);
            this.monster = (Monster)enemys[0].GetComponent(typeof(Monster));
        }

        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                enemys.Remove(enemys[index]);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            speed = maxSpeed;
            anim.SetBool("isWalk", true);
        }
    }
}
