using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextAlpha : MonoBehaviour
{
    Text myText;
    Outline myLine;
    void Start()
    {
        myText = GetComponent<Text>();
        myLine = GetComponent<Outline>();
        StartCoroutine(alphaDown());

    }

    IEnumerator alphaDown()
    {
        float alpha = 255;
        while (alpha>=0)
        {
            yield return new WaitForFixedUpdate();
            myText.color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
            myLine.effectColor = new Color(0 / 255, 0 / 255, 0 / 255, alpha / 255);
            alpha -= 10;
        }
        StartCoroutine(alphaUp());
    }
    IEnumerator alphaUp()
    {
        float alpha = 0;
        while (alpha <= 255)
        {
            yield return new WaitForFixedUpdate();
            myText.color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
            myLine.effectColor = new Color(0 / 255, 0 / 255, 0 / 255, alpha / 255);
            alpha += 10;
        }
        StartCoroutine(alphaDown());
    }
    void Update()
    {
        
    }
}
