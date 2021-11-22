using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [Header("Monster")]
    public GameObject basicMonster;
    public GameObject rangedMonster;

    [Header("Boss")]
    public GameObject boss1;
    public GameObject boss2;
    
    public void spawnBasic()
    {
        Instantiate(basicMonster);
    }

    public void spawnRanged()
    {
        Instantiate(rangedMonster);
    }









    // Boss

    public void spawnBoss1()
    {
        Instantiate(boss1);
    }
    public void spawnBoss2()
    {
        Instantiate(boss2);
    }


    void Start()
    {
        
    }

    

    void Update()
    {
        
    }
}
