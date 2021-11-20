using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject basicMonster;
    
    public void spawnBasic()
    {
        Instantiate(basicMonster);
    }
    void Start()
    {
        
    }

    

    void Update()
    {
        
    }
}
