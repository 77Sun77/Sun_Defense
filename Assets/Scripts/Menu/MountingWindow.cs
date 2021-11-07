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
    int hp;
    int damage;
    int cost;
    UnitMount unit;
    
    public void SetContect(string rating, int hp, int damage, int cost, UnitMount unit)
    {
        this.rating = rating;
        this.hp = hp;
        this.damage = damage;
        this.cost = cost;
        this.unit = unit;

        ratingText.text = rating;
        nameText.text = unit.unitName;
        statsText.text = "HP :" + hp + "\n" + "Dmg : " + damage + "\n" + "Cost : " + cost;
        unitImage.sprite = unit.image;
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
