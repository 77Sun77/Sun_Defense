using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text myText;
    public Outline oneOutline, twoOutline;
    void Start()
    {
        StartCoroutine(alphaUp());
    }

    IEnumerator alphaUp()
    {
        float alpha = 0;
        while (alpha <= 255)
        {
            yield return new WaitForFixedUpdate();
            myText.color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
            if(twoOutline == null) oneOutline.effectColor = new Color(0 / 255, 116 / 255, 255 / 255, alpha / 255);
            else twoOutline.effectColor = new Color(255 / 255, 56 / 255, 0 / 255, alpha / 255);
            alpha += 6;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(objectUp());
    }

    IEnumerator objectUp()
    {
        int height = -190;
        while (transform.localPosition.y <= -50)
        {
            yield return new WaitForFixedUpdate();
            transform.localPosition = new Vector2(0, height);
            height += 5;
        }
        yield return new WaitForSeconds(1f);
    }

    public void moveMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void gameStart()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
