using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMonsterRazer : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * 1.5f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.tag == "Unit")
        {
            Unit unit = (Unit)enemy.GetComponent(typeof(Unit));
            unit.Hp = 3;
            unit.Hit();
            Destroy(gameObject);
        }
        if(enemy.tag == "Castle")
        {
            Castle castle = (Castle)enemy.GetComponent(typeof(Castle));
            castle.hp -= 3;
            castle.Hit();
            Destroy(gameObject);
        }
    }
}
