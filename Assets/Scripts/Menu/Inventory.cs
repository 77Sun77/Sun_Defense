using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<string> holdCommon = new List<string>();
    public Transform inventoryPlace;
    public GameObject mountingWindow;
    public static GameObject mountingWin;

    [Header("Common")]
    public UnitMount[] common = new UnitMount[10];

    [Header("Rare")]
    public UnitMount[] rare = new UnitMount[7];

    [Header("Legendary")]
    public UnitMount[] legendary = new UnitMount[5];


    void SetCommon()
    {
        for(int i=0;i< inventoryPlace.childCount; i++)
        {
             
            Destroy(inventoryPlace.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < 10; i++)
        {
            for(int j = 0; j < holdCommon.Count; j++)
            {
                
                if (common[i].unitName == holdCommon[j])
                {
                    Instantiate(common[i].gameObject, inventoryPlace);
                }
            }
        }
    }
    private void OnEnable()
    {
        SetCommon();
        mountingWin = mountingWindow;
    }

    
    void Update()
    {
        
    }
}
