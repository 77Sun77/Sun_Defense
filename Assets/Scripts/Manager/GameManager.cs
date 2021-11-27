using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    SpawnMonster monsterController;
    int stage=29;
    
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

    AudioSource bgm;

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
        PlayerPrefs.SetInt("money", Money.money);
        StopAllCoroutines();
    }
    void GameLose()
    {
        lose.SetActive(true);
        StopAllCoroutines();
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

    IEnumerator stage11()
    {
        count = 5;
        getMoney = 150;
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(4f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(4f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();

    }

    IEnumerator stage12()
    {
        count = 7;
        getMoney = 150;
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();

    }

    IEnumerator stage13()
    {
        count = 15;
        getMoney = 150;
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

        yield return new WaitForSeconds(2f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();

        yield return new WaitForSeconds(4f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();

    }

    IEnumerator stage14()
    {
        count = 20;
        getMoney = 150;
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
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(5f);
        monsterController.spawnBlackObject();

    }

    IEnumerator stage15()
    {
        count = 1;
        getMoney = 300;
        yield return new WaitForSeconds(0.1f);
        monsterController.spawnBoss3();
        

    }

    IEnumerator stage16()
    {
        count = 15;
        getMoney = 250;
        
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
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(5f);
        monsterController.spawnFast();

        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();

    }

    IEnumerator stage17()
    {
        count = 15;
        getMoney = 250;

        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(5f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();

    }

    IEnumerator stage18()
    {
        count = 10;
        getMoney = 250;

        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();

    }
    IEnumerator stage19()
    {
        count = 15;
        getMoney = 250;

        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();

        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();

        yield return new WaitForSeconds(5f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(3f);
        monsterController.spawnFast();

    }

    IEnumerator stage20()
    {
        count = 1;
        getMoney = 2100;

        yield return new WaitForSeconds(5f);
        monsterController.spawnBoss4();
    }

    IEnumerator stage21()
    {
        count = 5;
        getMoney = 300;

        yield return new WaitForSeconds(3f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();

    }

    IEnumerator stage22()
    {
        count = 10;
        getMoney = 300;

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

        yield return new WaitForSeconds(5f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();

    }

    IEnumerator stage23()
    {
        count = 10;
        getMoney = 300;

        yield return new WaitForSeconds(3f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(5f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(5f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();

        yield return new WaitForSeconds(5f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();

    }

    IEnumerator stage24()
    {
        count = 12;
        getMoney = 300;

        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();

        yield return new WaitForSeconds(5f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
    }

    IEnumerator stage25()
    {
        count = 1;
        getMoney = 1000;

        yield return new WaitForSeconds(5f);
        monsterController.spawnBoss5();
    }

    IEnumerator stage26()
    {
        count = 10;
        getMoney = 300;

        yield return new WaitForSeconds(3f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();

        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
    }

    IEnumerator stage27()
    {
        count = 15;
        getMoney = 300;

        yield return new WaitForSeconds(3f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();

        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();

        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(3f);
        monsterController.spawnRanged();
    }

    IEnumerator stage28()
    {
        count = 20;
        getMoney = 300;

        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();

        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();

        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(5f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(5f);
        monsterController.spawnFast();
    }

    IEnumerator stage29()
    {
        count = 30;
        getMoney = 300;

        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(15f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(5f);
        monsterController.spawnFast();

        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();
        yield return new WaitForSeconds(3f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(3f);
        monsterController.spawnBasic();

        yield return new WaitForSeconds(7f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(5f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(5f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(5f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(5f);
        monsterController.spawnStrong();

        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();

        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();
        yield return new WaitForSeconds(5f);
        monsterController.spawnRanged();

        yield return new WaitForSeconds(5f);
        monsterController.spawnFast();
        yield return new WaitForSeconds(2f);
        monsterController.spawnFast();

        yield return new WaitForSeconds(5f);
        monsterController.spawnStrong();
        yield return new WaitForSeconds(5f);
        monsterController.spawnStrong();

        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
        yield return new WaitForSeconds(7f);
        monsterController.spawnAlien();
    }
    IEnumerator stage30()
    {
        count = 2;

        yield return new WaitForSeconds(5f);
        monsterController.spawnBoss6();
    }

}
