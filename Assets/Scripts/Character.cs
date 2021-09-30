using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected int maxHp;
    public int hp;
    protected int damage;
    protected float maxSpeed;
    protected float speed;
    protected float attackSpeed;
    protected Animator anim;


    protected/*override*/ void Death()
    {
        Destroy(gameObject);
    }
}
