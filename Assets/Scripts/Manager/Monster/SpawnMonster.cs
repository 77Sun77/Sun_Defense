using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [Header("Monster")]
    public GameObject basicMonster;
    public GameObject rangedMonster;
    public GameObject strongMonster;
    public GameObject fastMonster;

    [Header("Boss")]
    public GameObject boss1;
    public GameObject boss2;
    public GameObject blackObject, boss3;
    public void spawnBasic()
    {
        Instantiate(basicMonster);
    }

    public void spawnRanged()
    {
        Instantiate(rangedMonster);
    }

    public void spawnStrong()
    {
        Instantiate(strongMonster);
    }

    public void spawnFast()
    {
        Instantiate(fastMonster);
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


    public void spawnBlackObject()
    {
        Instantiate(blackObject);
    }
    public void spawnBoss3()
    {
        Instantiate(boss3);
    }

    void Start()
    {
        
    }

    

    void Update()
    {
        
    }
}
