using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D enemy) 
    {
        if(enemy.tag == "Monster")
        {
            Monster monster = (Monster)enemy.GetComponent(typeof(Monster));
            monster.Hp = 9;
            monster.Hit();
        }
    }
}
