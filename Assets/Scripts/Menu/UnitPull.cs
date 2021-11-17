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
        commonList.Add("����");
        commonList.Add("���ô�");
        commonList.Add("���ݺ�");
        commonList.Add("����");
        commonList.Add("����������");
        commonList.Add("����");
        commonList.Add("���۸�");
        commonList.Add("������");

        rareList.Add("��Ȱ��");
        rareList.Add("�ڿ���");
        rareList.Add("�ĵ�����");
        rareList.Add("����");
        rareList.Add("���谡");
        rareList.Add("���");
        rareList.Add("������");

        legendaryList.Add("�¾��� ���");
    }

    
    public void CommonPull()
    {
        if (100 < Money.money) return;

        int randomNumber = Random.Range(0, commonList.Count);
        print(commonList[randomNumber]+"����");
        Inventory.holdCommon.Add(commonList[randomNumber]);
        SaveCommon(randomNumber);
        commonList.RemoveAt(randomNumber);
    }

    public void RarePull()
    {
        if (500 < Money.money) return;

        int randomNumber = Random.Range(0, rareList.Count);
        print(rareList[randomNumber] + "����");
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
        Inventory.holdCommon.Add("���");
        Inventory.holdCommon.Add("�ü�");
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
