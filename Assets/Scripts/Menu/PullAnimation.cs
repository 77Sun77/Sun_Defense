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
        if (unit == "����") image.sprite = common[0];
        if (unit == "���ô�") image.sprite = common[1];
        if (unit == "���ݺ�") image.sprite = common[2];
        if (unit == "����") image.sprite = common[3];
        if (unit == "����������") image.sprite = common[4];
        if (unit == "����") image.sprite = common[5];
        if (unit == "���۸�") image.sprite = common[6];
        if (unit == "������") image.sprite = common[7];
        unitText.text = unit;
    }
    public void Rare(string unit)
    {
        if (unit == "��Ȱ��") image.sprite = rare[0];
        if (unit == "�ڿ���") image.sprite = rare[1];
        if (unit == "�ĵ�����") image.sprite = rare[2];
        if (unit == "����") image.sprite = rare[3];
        if (unit == "���谡") image.sprite = rare[4];
        if (unit == "���") image.sprite = rare[5];
        if (unit == "������") image.sprite = rare[6];
        unitText.text = unit;
    }

    public void Legendary(string unit)
    {
        if (unit == "�ձ� ���") image.sprite = legendary[0];
        if (unit == "����") image.sprite = legendary[1];
        if (unit == "�����") image.sprite = legendary[2];
        if (unit == "õ��") image.sprite = legendary[3];
        if (unit == "������ ����") image.sprite = legendary[4];
        unitText.text = unit;
    }
}
