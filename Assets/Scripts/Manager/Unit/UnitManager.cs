using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    public GameObject[] place = new GameObject[5];
    public static List<GameObject> unitButtons = new List<GameObject>();
    public static List<string> units = new List<string>();
    
    public GameObject reminder;
    GameObject ui;

    void Start()
    {
        ui = GameObject.Find("MainUI");
        SetButton();
    }

    void SetButton()
    {
        for(int i=0;i< unitButtons.Count; i++)
        {
            Instantiate(unitButtons[i], place[i].transform);
            print(i);
        }
    }

    public void UnitMounting(GameObject unit, string unitName)
    {
        unitButtons.Add(unit);
        units.Add(unitName);
    }
    public void ReminderMessage()
    {
        Instantiate(reminder, ui.transform);
    }
}
