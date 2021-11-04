using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMount : MonoBehaviour
{
    public GameObject unit;
    public string unitName;
    void Start()
    {
        
    }

    public void Mounting()
    {
        UnitManager unit = new UnitManager();
        unit.UnitMounting(this.unit, unitName);
    }
    void Update()
    {
        
    }
}
