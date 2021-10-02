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
    protected float skillSpeed;
    protected Animator anim;
    protected SpriteRenderer mySprite;

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
    
    public IEnumerator Hit()
    {
        mySprite.color = new Color(255 / 255f, 100 / 255f, 100 / 255f);
        yield return new WaitForSeconds(0.1f);
        mySprite.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    }
}
