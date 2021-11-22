using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    SpawnMonster monsterController;
    int stage=10;
    
    public static int count;
    public Text countText;

    [Header("Material")]
    public Slider materialSlider;
    public Text materialText;
    public static float material;

    bool isGame;
    public Text titleText;

    public Text moneyText;
    int money;
    int getMoney;

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
       // stage = PlayerPrefs.GetInt("stage");
        if (stage == 0) stage = 1;
        
    }
    void setStage()
    {
        stage++;
        PlayerPrefs.SetInt("stage", stage); 
    }


    public GameObject win;
    public GameObject lose;
    void Update()
    {
        countText.text = "³²Àº Àû : " + count;

        MaterialUp();
        materialSlider.value = material;
        materialText.text = (int)material + "/" + materialSlider.maxValue;


        if (isGame)
        {
            Castle castle = GameObject.Find("Castle").GetComponent<Castle>();
            if (castle.hp <= 0)
            {
                Invoke("GameLose", 1f);
                isGame = false;
            }
            if(count <= 0)
            {
                Invoke("GameWin", 1f);
                isGame = false;
            }
        }
    }

    void GameWin()
    {
        setStage();
        win.SetActive(true);
        money = Money.money;
        moneyText.text = money + "+" + getMoney;
        Money.money += getMoney;
    }
    void GameLose()
    {
        lose.SetActive(true);
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
        getMoney = 50;
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
        getMoney = 50;
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
        count = 6;
        getMoney = 50;
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
    }

    IEnumerator stage4()
    {
        count = 7;
        getMoney = 50;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(6f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(6f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(6f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(6f);
        monsterController.spawnBasic();

    }

    IEnumerator stage5()
    {
        count = 1;
        getMoney = 200;
        yield return new WaitForSeconds(5f);
        monsterController.spawnBoss1();
    }

    IEnumerator stage6()
    {
        count = 7;
        getMoney = 100;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(7f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
    }

    IEnumerator stage7()
    {
        count = 7;
        getMoney = 100;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(5f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(4f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(4f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
    }

    IEnumerator stage8()
    {
        count = 10;
        getMoney = 100;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(4f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
    }

    IEnumerator stage9()
    {
        count = 15;
        getMoney = 100;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(4f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
    }

    IEnumerator stage10()
    {
        count = 5;
        getMoney = 600;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(2f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(2f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(2f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(9f);
        monsterController.spawnBoss2();

    }
}
