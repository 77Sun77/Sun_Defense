using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArrow : MonoBehaviour
{
    BoxCollider2D myCollider;
    private void OnEnable()
    {
        myCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(arrowAttack());
    }

    IEnumerator arrowAttack()
    {
        yield return new WaitForSeconds(0.4f);
        myCollider.enabled = true;
        yield return new WaitForSeconds(0.7f);
        myCollider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.tag == "Monster")
        {
            Monster monster = (Monster)enemy.GetComponent(typeof(Monster));
            monster.Hp = 3;
            monster.Hit();
        }
    }

}
