using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPull : MonoBehaviour
{
    List<string> commonList = new List<string>();
    List<string> rareList = new List<string>();
    List<string> legendaryList = new List<string>();
    List<string> temp = new List<string>();

    public GameObject common, rare, legendary;

    public GameObject commonAnim, rareAnim, legendaryAnim;
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

        legendaryList.Add("�ձ� ���");
        legendaryList.Add("����");
        legendaryList.Add("�����");
        legendaryList.Add("õ��");
        legendaryList.Add("������ ����");
    }

    
    public void CommonPull()
    {
        if (100 > Money.money) return;

        int randomNumber = Random.Range(0, commonList.Count);
        print(commonList[randomNumber]+"����");

        commonAnim.SetActive(true);
        commonAnim.GetComponent<PullAnimation>().Common(commonList[randomNumber]);

        Inventory.holdCommon.Add(commonList[randomNumber]);
        SaveCommon(randomNumber);
        commonList.RemoveAt(randomNumber);
        Money.money -= 100;
        PlayerPrefs.SetInt("money", Money.money);
    }

    public void RarePull()
    {
        if (500 > Money.money) return;

        int randomNumber = Random.Range(0, rareList.Count);
        print(rareList[randomNumber] + "����");

        rareAnim.SetActive(true);
        rareAnim.GetComponent<PullAnimation>().Rare(rareList[randomNumber]);

        Inventory.holdRare.Add(rareList[randomNumber]);
        SaveRare(randomNumber);
        rareList.RemoveAt(randomNumber);
        Money.money -= 500;
        PlayerPrefs.SetInt("money", Money.money);
    }
    public void LegendaryPull()
    {
        if (1000 > Money.money) return;

        int randomNumber = Random.Range(0, legendaryList.Count);
        print(legendaryList[randomNumber] + "����");

        legendaryAnim.SetActive(true);
        legendaryAnim.GetComponent<PullAnimation>().Legendary(legendaryList[randomNumber]);

        Inventory.holdLegendary.Add(legendaryList[randomNumber]);
        SaveLegendary(randomNumber);
        legendaryList.RemoveAt(randomNumber);
        Money.money -= 1000;
        PlayerPrefs.SetInt("money", Money.money);
    }


    void LoadingUnits()
    {
        // ���� �ʱ�ȭ
        Inventory.holdCommon.Clear();
        Inventory.holdRare.Clear();
        Inventory.holdLegendary.Clear();

        // �Ϲ� ���� �ε�
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

        // ��� ���� �ε�
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

        // ���� ���� �ε�
        for (int i = 0; i < 5; i++)
        {
            string unit = PlayerPrefs.GetString(legendaryList[i]);
            if (unit != "")
            {
                Inventory.holdLegendary.Add(unit);
                temp.Add(legendaryList[i]);
            }
        }
        for (int i = 0; i < temp.Count; i++)
        {
            legendaryList.Remove(temp[i]);
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
    void SaveLegendary(int num)
    {
        PlayerPrefs.SetString(legendaryList[num], legendaryList[num]);
    }

    void Update()
    {
        if (commonList.Count == 0)
        {
            common.SetActive(false);
        }
        if (rareList.Count == 0)
        {
            rare.SetActive(false);
        }
        if (legendaryList.Count == 0)
        {
            legendary.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();

        }
    }
}
