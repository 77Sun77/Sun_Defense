using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    public GameObject[] place = new GameObject[5];
    public static List<GameObject> unitButtons = new List<GameObject>();
    List<string> units = new List<string>();
    public GameObject blank;
    
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
            place[i] = Instantiate(unitButtons[i]);
        }
        for(int i=unitButtons.Count; i < 5; i++)
        {
            place[i] = Instantiate(blank);
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
