using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossSkill : MonoBehaviour
{
    Unit unit;
    Castle castle;

    int damage;
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 7f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Unit")
        {
            if (collision.GetComponent(typeof(RareVeterans)) != null) damage = 5;
            else damage = 100;
            unit = (Unit)collision.GetComponent(typeof(Unit));
            unit.Hit();
            unit.Hp = damage;
        }
        if(collision.tag == "Castle")
        {
            castle = (Castle)collision.GetComponent(typeof(Castle));
            damage = 5;
            castle.Hit();
            castle.hp -= damage;
        }
    }
}
