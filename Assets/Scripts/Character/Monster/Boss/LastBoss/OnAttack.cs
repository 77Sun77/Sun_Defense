using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttack : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Unit" || collision.tag == "Castle")
        {
            anim.SetTrigger("attackReady");
            BoxCollider2D myCollier = GetComponent<BoxCollider2D>();
            myCollier.enabled = false;
            LastBoss lastBoss = anim.GetComponent<LastBoss>();
            lastBoss.isAttack = true;
        }
    }
}
