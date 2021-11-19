using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelHealling : MonoBehaviour
{
    BoxCollider2D myCollider;
    Unit unit;
    private void OnEnable()
    {
        myCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(HeallingTime());
    }
    IEnumerator HeallingTime()
    {
        yield return new WaitForSeconds(0.4f);
        myCollider.enabled = true;
        yield return new WaitForSeconds(0.4f);
        myCollider.enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D unit)
    {
        if(unit.tag == "Unit")
        {
            this.unit = (Unit)unit.GetComponent(typeof(Unit));
            this.unit.hp += 7;
            if (this.unit.hp > this.unit.maxHp) this.unit.hp = this.unit.maxHp;
            print(this.unit);
        }
    }
}
