using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBullet : MonoBehaviour
{
    public GameObject waveMan;
    public GameObject damage;
    void Update()
    {
        transform.Translate(Vector2.right * 3f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster")
        {
            Monster monster = (Monster)enemy.GetComponent(typeof(Monster));
            int randomDamage = Random.Range(4, 11);
            monster.Hp = randomDamage;
            monster.Hit();
            GameObject damageText = Instantiate(damage, waveMan.transform);
            damageText.GetComponent<DamageText>().damageText.text = randomDamage + "DMG";
            Destroy(gameObject);
        }
    }
}
