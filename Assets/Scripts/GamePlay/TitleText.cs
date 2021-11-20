using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleText : MonoBehaviour
{
    Text myText;
    void Start()
    {
        myText = GetComponent<Text>();
        StartCoroutine(alphaUp());
    }

    IEnumerator alphaUp()
    {
        float alpha = 0;
        while (alpha <= 255)
        {
            yield return new WaitForFixedUpdate();
            myText.color = new Color(0 / 255, 0 / 255, 0 / 255, alpha / 255);
            alpha += 3;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(alphaDown());
    }

    IEnumerator alphaDown()
    {
        float alpha = 255;
        while (alpha >= 0)
        {
            yield return new WaitForFixedUpdate();
            myText.color = new Color(0 / 255, 0 / 255, 0 / 255, alpha / 255);
            alpha -= 3;
        }
        gameObject.SetActive(false);
    }
    
    void Update()
    {
        
    }
}
