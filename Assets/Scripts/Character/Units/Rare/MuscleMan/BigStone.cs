using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStone : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 1.5f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.tag == "Monster")
        {
            Monster monster = (Monster)enemy.GetComponent(typeof(Monster));
            monster.Hp = 5;
            monster.Hit();
        }
    }
}
