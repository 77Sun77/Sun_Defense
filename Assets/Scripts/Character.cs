using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected enum State { live, death };
    State state = State.live;
    protected int maxHp;
    public int hp;
    protected int damage;
    protected float maxSpeed;
    protected float speed;
    protected float attackSpeed;
    protected Animator anim;

    public enum monsterKinds { Basic };
    public virtual void Attack()
    {

    }
    public int Hp
    {
        get 
        {
            return hp;
        }
        set 
        {
            hp -= value;
            if (hp <= 0) Death();
        }
    }
    public virtual void Death()
    {
        Destroy(gameObject);
    }
    

}
