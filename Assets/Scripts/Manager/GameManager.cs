using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    SpawnMonster monsterController;
    string stage = "stage1";
    
    public static int count=5;
    public Text countText;
    
    public static float material;
    void Start()
    {
        StartCoroutine(stage);
        monsterController = GetComponent<SpawnMonster>();
    }

    
    IEnumerator stage1()
    {
        yield return new WaitForSeconds(1f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();

    }
    void Update()
    {
        countText.text = "³²Àº Àû : " + count;
    }
}
