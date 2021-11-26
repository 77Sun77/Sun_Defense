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
    public GameObject alienMonster;

    [Header("Boss")]
    public GameObject boss1;
    public GameObject boss2;
    public GameObject blackObject, boss3;
    public GameObject boss4;
    public GameObject boss5;
    public GameObject boss6;

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

    public void spawnAlien()
    {
        Instantiate(alienMonster);
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


    public void spawnBoss4()
    {
        Instantiate(boss4);
    }
    public void spawnBoss5()
    {
        Instantiate(boss5);
    }
    public void spawnBoss6()
    {
        Instantiate(boss6);
    }

    void Start()
    {
        
    }

    

    void Update()
    {
        
    }
}
