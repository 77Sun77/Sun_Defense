using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPull : MonoBehaviour
{
    List<string> commonList = new List<string>();
    List<string> rareList = new List<string>();
    List<string> legendaryList = new List<string>();
    List<string> temp = new List<string>();
    private void SetList()
    {
        commonList.Add("거지");
        commonList.Add("도련님");
        commonList.Add("돌격병");
        commonList.Add("고릴라");
        commonList.Add("얼음마법사");
        commonList.Add("닌자");
        commonList.Add("슈퍼맨");
        commonList.Add("보류");

        rareList.Add("부활자");
        rareList.Add("자연인");

        legendaryList.Add("태양의 기사");
    }

    
    public void CommonPull()
    {
        if (100 < Money.money) return;

        int randomNumber = Random.Range(0, commonList.Count);
        print(commonList[randomNumber]+"등장");
        Inventory.holdCommon.Add(commonList[randomNumber]);
        SavaUnit(randomNumber);
        commonList.RemoveAt(randomNumber);
    }

    public void RarePull()
    {
        if (500 < Money.money) return;
    }

    public void LegendaryPull()
    {
        if (1000 < Money.money) return;
    }


    void LoadingUnits()
    {
        Inventory.holdCommon.Add("기사");
        Inventory.holdCommon.Add("궁수");
        for (int i = 0; i < 8; i++)
        {
            string unit = PlayerPrefs.GetString(commonList[i]);
            if (unit != "")
            {
                Inventory.holdCommon.Add(unit);
                temp.Add(commonList[i]);
            }

        }
        for (int i = 0; i < temp.Count; i++)
        {
            commonList.Remove(temp[i]);
        }
    }


    void Start()
    {
        SetList();
        LoadingUnits();


    }

    void SavaUnit(int num)
    {
        PlayerPrefs.SetString(commonList[num], commonList[num]);
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();

        }
    }
}
