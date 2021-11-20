using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMount : MonoBehaviour
{
    public GameObject unit;
    public Sprite image;
    public string unitName;

    GameObject ui;
    void Start()
    {
        ui = GameObject.Find("UI");
    }

    public void Mounting()
    {
        UnitManager unit = new UnitManager();
        UnitMounted unitMount = new UnitMounted();
        for (int i = 0; i < UnitManager.units.Count; i++)
        {
            if (UnitManager.units[i] == unitName)
            {
                Instantiate(UnitMounted.inUse, ui.transform);
                return;
            }
        }
        if (UnitManager.units.Count < 5)
        {
            unit.UnitMounting(this.unit, unitName);
        }
        unitMount.Mounting(gameObject);
    }

    [Header("Stats")]
    public string rating;
    public string hp;
    public string damage;
    public int cost;
    public string specialAbility;

    public void OpenWindow()
    {
        UnitMount unitMount = GetComponent<UnitMount>();
        GameObject window = Instantiate(Inventory.mountingWin, ui.transform);
        MountingWindow mountingWindow = window.GetComponent<MountingWindow>();
        mountingWindow.SetContect(rating, hp, damage, cost, unitMount, specialAbility);
    }

    void Update()
    {
        
    }
}
