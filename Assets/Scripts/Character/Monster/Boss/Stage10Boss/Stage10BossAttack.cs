using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage10BossAttack : MonoBehaviour
{

    private void OnEnable()
    {
        Invoke("activeFalse", 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void activeFalse()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D unit)
    {
        if(unit.tag == "Unit")
        {
            Unit thisUnit = (Unit)unit.GetComponent(typeof(Unit));
            thisUnit.Hit();
            thisUnit.Hp = 5;
        }
    }
}
