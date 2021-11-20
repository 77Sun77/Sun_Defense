using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    SpawnMonster monsterController;
    int stage=3;
    
    public static int count;
    public Text countText;

    [Header("Material")]
    public Slider materialSlider;
    public Text materialText;
    public static float material;

    bool isGame;
    public Text titleText;

    void Start()
    {
        materialSlider.maxValue = 400;
        material = 40;
        getStage();
        titleText.text = "Stage " + stage;
        StartCoroutine("stage"+stage.ToString());
        monsterController = GetComponent<SpawnMonster>();
        isGame = true;
    }

    void getStage()
    {
        if (stage == 0)
        {
            stage = 1;
        }
        else
        {
          //  stage = PlayerPrefs.GetInt("stage");
        }
    }
    void setStage()
    {
        stage++;
        PlayerPrefs.SetInt("stage", stage); 
    }
    
    void Update()
    {
        countText.text = "남은 적 : " + count;

        MaterialUp();
        materialSlider.value = material;
        materialText.text = (int)material + "/" + materialSlider.maxValue;


        if (isGame)
        {
            Castle castle = GameObject.Find("Castle").GetComponent<Castle>();
            if (castle.hp <= 0)
            {
                // 패배 함수
                isGame = false;
            }
            if(count <= 0)
            {
                // 승리 함수
                isGame = false;
            }
        }
    }

    void MaterialUp()
    {
        if (material > materialSlider.maxValue)
        {
            material = materialSlider.maxValue;
            return;
        }

        material += 0.2f;
    }

    IEnumerator stage1()
    {
        count = 3;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
    }

    IEnumerator stage2()
    {
        count = 5;
        yield return new WaitForSeconds(3f);
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

    IEnumerator stage3()
    {
        count = 7;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
    }

    IEnumerator stage4()
    {
        count = 7;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

    }
}
