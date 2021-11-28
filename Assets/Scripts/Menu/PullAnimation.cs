using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullAnimation : MonoBehaviour
{
    public GameObject top;
    public Image whiteBG;
    float alpha;
    public GameObject skipButtton;
    public GameObject window;

    public GameObject imageGO;
    public Image image;
    public Text unitText;
    public Sprite[] common = new Sprite[8];
    public Sprite[] rare = new Sprite[7];
    public Sprite[] legendary = new Sprite[5];

    private void OnEnable()
    {
        alpha = 0;
        StartCoroutine(TopUp());
    }
    IEnumerator TopUp()
    {
        yield return new WaitForSeconds(1f);
        while (top.transform.localPosition.y < 195)
        {
            yield return new WaitForFixedUpdate();
            top.transform.Translate(Vector2.up * 200 * Time.deltaTime);
        }
        top.transform.localPosition = new Vector2(0, 195);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(alphaUp());
    }
    IEnumerator alphaUp()
    {
        while(alpha <= 255)
        {
            yield return new WaitForFixedUpdate();
            alpha += 10;
            whiteBG.color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(alphaDown());
    }
    IEnumerator alphaDown()
    {
        window.SetActive(false);
        imageGO.SetActive(true);
        skipButtton.SetActive(false);
        while (alpha >= 0)
        {
            yield return new WaitForFixedUpdate();
            alpha -= 20;
            whiteBG.color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
        }
    }

    public void SkipAnim()
    {
        StopAllCoroutines();
        whiteBG.color = new Color(255 / 255, 255 / 255, 255 / 255, 0 / 255);
        skipButtton.SetActive(false);
        window.SetActive(false);
        imageGO.SetActive(true);
    }

    public void activeFalse()
    {
        gameObject.SetActive(false);
        window.SetActive(true);
        imageGO.SetActive(false);
        skipButtton.SetActive(true);
        top.transform.localPosition = new Vector2(0, 56.851f);
    }
    public void Common(string unit)
    {
        if (unit == "거지") image.sprite = common[0];
        if (unit == "도련님") image.sprite = common[1];
        if (unit == "돌격병") image.sprite = common[2];
        if (unit == "고릴라") image.sprite = common[3];
        if (unit == "얼음마법사") image.sprite = common[4];
        if (unit == "닌자") image.sprite = common[5];
        if (unit == "슈퍼맨") image.sprite = common[6];
        if (unit == "나무꾼") image.sprite = common[7];
        unitText.text = unit;
    }
    public void Rare(string unit)
    {
        if (unit == "부활자") image.sprite = rare[0];
        if (unit == "자연인") image.sprite = rare[1];
        if (unit == "파동술사") image.sprite = rare[2];
        if (unit == "집사") image.sprite = rare[3];
        if (unit == "모험가") image.sprite = rare[4];
        if (unit == "용사") image.sprite = rare[5];
        if (unit == "근육맨") image.sprite = rare[6];
        unitText.text = unit;
    }

    public void Legendary(string unit)
    {
        if (unit == "왕궁 기사") image.sprite = legendary[0];
        if (unit == "엘프") image.sprite = legendary[1];
        if (unit == "가디언") image.sprite = legendary[2];
        if (unit == "천사") image.sprite = legendary[3];
        if (unit == "원시족 족장") image.sprite = legendary[4];
        unitText.text = unit;
    }
}
