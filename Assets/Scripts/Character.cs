using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected List<Collider2D> enemys = new List<Collider2D>();
    public Collider2D myCollider;
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

    [SerializeField]
    protected Effect effect;

    protected bool isAttact;
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

    protected void SetComponent()
    {
        anim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
    
    public IEnumerator Hit()
    {
        mySprite.color = new Color(255 / 255f, 100 / 255f, 100 / 255f);
        StartCoroutine(ResetColor());
        yield return null;
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.1f);
        mySprite.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    }
}
