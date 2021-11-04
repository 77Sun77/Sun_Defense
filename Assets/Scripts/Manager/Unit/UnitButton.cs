using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public GameObject unit;
    public int cost;
    public UnitManager unitManager;
    public void spawnUnit()
    {
        if(GameManager.material >= cost)
        {
            Instantiate(unit);
            GameManager.material -= cost;
        }
        else
        {
            unitManager.ReminderMessage();
        }
    }
}
