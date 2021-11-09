using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountingWindow : MonoBehaviour
{
    public Text ratingText;
    public Text nameText;
    public Text statsText;
    public Image unitImage;
    

    string rating;
    string unitName;
    int hp;
    int damage;
    int cost;
    UnitMount unit;

    [Header("Button")]
    public GameObject setButton;
    public GameObject disableButton;


    int disableNumber;
    public void SetContect(string rating, int hp, int damage, int cost, UnitMount unit)
    {
        this.rating = rating;
        this.unitName = unit.unitName; 
        this.hp = hp;
        this.damage = damage;
        this.cost = cost;
        this.unit = unit;

        ratingText.text = rating;
        nameText.text = unit.unitName;
        statsText.text = "HP :" + hp + "\n" + "Dmg : " + damage + "\n" + "Cost : " + cost;
        unitImage.sprite = unit.image;




        if (UnitManager.units.Contains(unitName))
        {
            setButton.SetActive(false);
            disableButton.SetActive(true);
            disableNumber = UnitManager.units.IndexOf(unitName);
        }
        else
        {
            setButton.SetActive(true);
            disableButton.SetActive(false);
        }

    }

    public void DisableMounting()
    {
        UnitMounted.mountingUnit.RemoveAt(disableNumber);
        UnitManager.units.RemoveAt(disableNumber);
        UnitMounted.isMounting = true;
        GameObject unit;
        unit = GameObject.Find("Unit Mounting");
        unit.GetComponent<UnitMounted>().SetMounting();
        WindowDestroy();
    }

    public void Mounting()
    {
        unit.Mounting();
        WindowDestroy();
    }

    public void WindowDestroy()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
