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

    [Header("Material")]
    public Slider materialSlider;
    public Text materialText;
    public static float material;
    void Start()
    {
        materialSlider.maxValue = 400;
        material = 200;
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

        MaterialUp();
        materialSlider.value = material;
        materialText.text = (int)material + "/" + materialSlider.maxValue;
    }

    void MaterialUp()
    {
        if (material > materialSlider.maxValue)
        {
            material = materialSlider.maxValue;
            return;
        }

        material += 0.05f;
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            material -= 100;
        }
    }
}
