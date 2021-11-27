using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentaurSpear : MonoBehaviour
{
    Unit unit;
    Castle castle;
    int count;
    public string isAttack;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 5) Destroy(gameObject);
        transform.Translate(Vector2.left * 8f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Unit" && isAttack == "Monster")
        {
            unit = (Unit) collision.GetComponent(typeof(Unit));
            unit.Hit();
            unit.Hp = 30;
            count++;
        }
        if(collision.tag == "Castle" && isAttack == "Castle")
        {
            castle = (Castle)collision.GetComponent(typeof(Castle));
            castle.Hit();
            castle.hp -= 30;
            Destroy(gameObject, 3f);
        }
    }
}
