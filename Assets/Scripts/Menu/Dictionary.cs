using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour
{
    public Image basic, boss;
    public Sprite noneImage, checkImage;

    public GameObject basicWindow, bossWindow;

    string isChecked;

    [Header("Monster")]
    public Image[] imageSpace = new Image[5];
    public Sprite[] spriteSpace = new Sprite[5];
    Button[] monsterButton = new Button[5];

    [Header("Boss")]
    public Image[] imageSpace2 = new Image[7];
    public Sprite[] spriteSpace2 = new Sprite[7];
    Button[] bossButton = new Button[7];
    private void OnEnable()
    {
        isChecked = "basic";
        for(int i = 0; i < 5; i++)
        {
            monsterButton[i] = imageSpace[i].GetComponent<Button>();
            monsterButton[i].interactable = false;
        }
        for(int i = 0; i < 7; i++)
        {
            bossButton[i] = imageSpace2[i].GetComponent<Button>();
            bossButton[i].interactable = false;
        }
    }

    public void onBasic()
    {
        isChecked = "basic";
    }
    public void onBoss()
    {
        isChecked = "boss";
    }
    void Update()
    {
        if(isChecked == "basic")
        {
            basic.sprite = checkImage;
            boss.sprite = noneImage;
            basicWindow.SetActive(true);
            bossWindow.SetActive(false);
        }
        else
        {
            basic.sprite = noneImage;
            boss.sprite = checkImage;
            basicWindow.SetActive(false);
            bossWindow.SetActive(true);
        }

        imageSpace[0].sprite = spriteSpace[0];
        monsterButton[0].interactable = true;
        if (PlayerPrefs.GetInt("stage") > 5)
        {
            imageSpace[1].sprite = spriteSpace[1];
            imageSpace[1].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            monsterButton[1].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") > 10)
        {
            imageSpace[2].sprite = spriteSpace[2];
            imageSpace[2].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            monsterButton[2].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") > 15)
        {
            imageSpace[3].sprite = spriteSpace[3];
            imageSpace[3].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            monsterButton[3].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") > 20)
        {
            imageSpace[4].sprite = spriteSpace[4];
            imageSpace[4].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            monsterButton[4].interactable = true;
        }



        if (PlayerPrefs.GetInt("stage") >= 5)
        {
            imageSpace2[0].sprite = spriteSpace2[0];
            imageSpace2[0].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            bossButton[0].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") >= 10)
        {
            imageSpace2[1].sprite = spriteSpace2[1];
            imageSpace2[1].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            bossButton[1].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") >= 15)
        {
            imageSpace2[2].sprite = spriteSpace2[2];
            imageSpace2[2].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            bossButton[2].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") >= 20)
        {
            imageSpace2[3].sprite = spriteSpace2[3];
            imageSpace2[3].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            bossButton[3].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") >= 25)
        {
            imageSpace2[4].sprite = spriteSpace2[4];
            imageSpace2[4].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            bossButton[4].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") >= 30)
        {
            imageSpace2[5].sprite = spriteSpace2[5];
            imageSpace2[5].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            bossButton[5].interactable = true;
        }
        if (PlayerPrefs.GetInt("stage") >= 30)
        {
            imageSpace2[6].sprite = spriteSpace2[6];
            imageSpace2[6].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
            bossButton[6].interactable = true;
        }
    }
}
