using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public Slider hpSlider;
    public int hp;
    SpriteRenderer mySprite;
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        hpSlider.maxValue = 30;

    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = hp;
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
