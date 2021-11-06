using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPull : MonoBehaviour
{
    public int price;
    List<string> commonList = new List<string>();
    private void SetCommon()
    {
        commonList.Add("����");
        commonList.Add("���ô�");
        commonList.Add("���ݺ�");
        commonList.Add("����");
        commonList.Add("����������");
        commonList.Add("����");
        commonList.Add("���۸�");
        commonList.Add("����");
    }

    void CommonLoadingUnits()
    {
        Inventory.holdCommon.Add("���");
        Inventory.holdCommon.Add("�ü�");
        for (int i = 0; i < commonList.Count; i++)
        {
            string unit = PlayerPrefs.GetString(commonList[i]);
            if (unit != "")
            {
                Inventory.holdCommon.Add(unit);
                commonList.Remove(commonList[i]);
            }

        }
        for (int i = 0; i < commonList.Count; i++)
        {
            print(Inventory.holdCommon[i]);
        }
    }
    public void CommonPull()
    {
        if (price < Money.money) return;

        int randomNumber = Random.Range(0, commonList.Count);
        print(commonList[randomNumber]+"����");
        SavaUnit(randomNumber);
        commonList.RemoveAt(randomNumber);
    }

    public void RarePull()
    {

    }

    public void LegendaryPull()
    {

    }
    void Start()
    {
        SetCommon();
        CommonLoadingUnits();


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
