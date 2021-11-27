using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurFireBall : MonoBehaviour
{
    Unit unit;
    Castle castle;
    public string unitKind;
    private void OnEnable()
    {
        StartCoroutine(active());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator active()
    {
        yield return new WaitForSeconds(0.2f);
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        myCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Unit" && unitKind == "Unit")
        {
            unit = (Unit)collision.GetComponent(typeof(Unit));
            unit.Hit();
            unit.Hp = 8;
        }
        if (collision.tag == "Castle" && unitKind == "Castle")
        {
            castle = (Castle)collision.GetComponent(typeof(Castle));
            castle.Hit();
            castle.hp -= 8;
        }
    }
}
