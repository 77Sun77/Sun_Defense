using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Slider loadingBar;
    public Text text;

    bool isPlay;
    public Button playButton;

    int access;
    void Start()
    {
        access = PlayerPrefs.GetInt("access");
        if(access == 0)
        {
            access++;
            Money.money += 100;
            PlayerPrefs.SetInt("money", Money.money);
        }
        loadingBar.value = 0;
        isPlay = false;
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        while (loadingBar.value < 30)
        {
            loadingBar.value += 0.6f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(1f);
        while (loadingBar.value <= 63)
        {
            loadingBar.value += 0.6f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(2f);
        while (loadingBar.value <= 77)
        {
            loadingBar.value += 0.6f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(3f);
        while (loadingBar.value < 92)
        {
            loadingBar.value += 1f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.2f);
        while (loadingBar.value <= 99)
        {
            loadingBar.value += 1.8f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(1f);
        while (loadingBar.value < 100)
        {
            loadingBar.value += 0.5f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(1f);
        isPlay = true;
        loadingBar.gameObject.SetActive(false);
    }

    public void moveMenu()
    {
        MoveScene.nextScene = "Menu";
        SceneManager.LoadScene("LoadingScene");
    }

    void Update()
    {
        int number = (int)loadingBar.value;
        text.text = number + "%";

        if (isPlay)
        {
            playButton.gameObject.SetActive(true);
        }
    }
}
