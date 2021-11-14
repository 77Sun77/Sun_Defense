using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareButler : Unit
{
    // 레어 집사(재료 채워줌)
    private bool isState, isMove;
    public GameObject moneyUp;
    void Start()
    {
        maxHp = 10;
        hp = 10;
        damage = 0;
        maxSpeed = 1f;
        speed = maxSpeed;
        SetComponent();
        isState = false;
        isMove = true;
    }

    void move()
    {
        if (transform.position.x > -5f && isMove)
        {
            isState = true;
            isMove = false;
            anim.SetTrigger("isWalk");
        }
        if(transform.position.x < -5f) base.move();
    }

    IEnumerator MoneyUp()
    {
        int moneyCount = 0;
        while (moneyCount != 5)
        {
            yield return new WaitForSeconds(5f);
            GameObject moneyUpText = Instantiate(moneyUp, gameObject.transform);
            Destroy(moneyUpText, 1f);
            moneyCount++;
            GameManager.material += 100;
            while (moneyUpText != null)
            {
                moneyUpText.transform.Translate(Vector2.up * 1.2f * Time.deltaTime);
                yield return null;
            }
        }
        Destroy(gameObject, 0.5f);
    }
    void Update()
    {
        move();
        if (isState)
        {
            StartCoroutine(MoneyUp());
            isState = false;
        }
    }
}
