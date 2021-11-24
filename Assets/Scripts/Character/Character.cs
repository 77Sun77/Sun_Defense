using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum state { None, Freeze };
    public state myState;

    protected List<Collider2D> enemys = new List<Collider2D>();
    public Collider2D myCollider;
    public int maxHp;
    public int hp;
    protected int damage;
    public float maxSpeed;
    public float speed;
    protected float attackSpeed;
    protected float skillSpeed;
    protected Animator anim;
    protected SpriteRenderer mySprite;

    [SerializeField]
    protected Effect effect;

    protected bool isAttact;
    public int deathCount;

    public GameObject smoke;
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
        smoke = GameObject.Find("Smoke");
    }

    public virtual void Death()
    {
        GameObject smoke = Instantiate(this.smoke);
        smoke.transform.position = gameObject.transform.position;
        Destroy(smoke, 3);
        Destroy(gameObject);
    }
    
    public void Hit()
    {
        mySprite.color = new Color(255 / 255f, 100 / 255f, 100 / 255f);
        StartCoroutine(ResetColor());
        
    }

    IEnumerator ResetColor()
    {
        float time = 0;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            time += Time.deltaTime;
            if (time >= 0.1)
            {
                mySprite.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                break;
            }
        }
    }
}
