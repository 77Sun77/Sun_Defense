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
    public void CommonPull()
    {
        if (price < Money.money) return;

        int randomNumber = Random.Range(0, commonList.Count);
        print(commonList[randomNumber]+"����");
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
