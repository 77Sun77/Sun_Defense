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
        commonList.Add("나무꾼");

        rareList.Add("부활자");
        rareList.Add("자연인");
        rareList.Add("파동술사");
        rareList.Add("집사");
        rareList.Add("모험가");
        rareList.Add("용사");
        rareList.Add("근육맨");

        legendaryList.Add("태양의 기사");
    }

    
    public void CommonPull()
    {
        if (100 < Money.money) return;

        int randomNumber = Random.Range(0, commonList.Count);
        print(commonList[randomNumber]+"등장");
        Inventory.holdCommon.Add(commonList[randomNumber]);
        SaveCommon(randomNumber);
        commonList.RemoveAt(randomNumber);
    }

    public void RarePull()
    {
        if (500 < Money.money) return;

        int randomNumber = Random.Range(0, rareList.Count);
        print(rareList[randomNumber] + "등장");
        Inventory.holdRare.Add(rareList[randomNumber]);
        SaveRare(randomNumber);
        rareList.RemoveAt(randomNumber);
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

        for (int i = 0; i < 7; i++)
        {
            string unit = PlayerPrefs.GetString(rareList[i]);
            if (unit != "")
            {
                Inventory.holdRare.Add(unit);
                temp.Add(rareList[i]);
            }
        }
        for (int i = 0; i < temp.Count; i++)
        {
            rareList.Remove(temp[i]);
        }
    }


    void Start()
    {
        SetList();
        LoadingUnits();


    }

    void SaveCommon(int num)
    {
        PlayerPrefs.SetString(commonList[num], commonList[num]);
    }
    void SaveRare(int num)
    {
        PlayerPrefs.SetString(rareList[num], rareList[num]);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();

        }
    }
}
