using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public GameObject unit;
    public int cost;
    UnitManager unitManager=new UnitManager();

    GameObject spawnPoint;

    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
    }

    public void spawnUnit()
    {
        if(GameManager.material >= cost)
        {
            GameObject unit = Instantiate(this.unit);
            unit.transform.position = new Vector2(spawnPoint.transform.position.x, unit.transform.position.y);
            GameManager.material -= cost;
        }
    }
}
