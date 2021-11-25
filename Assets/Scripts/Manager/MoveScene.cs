using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public static string nextScene;
    public Slider loadingBar;
    void Start()
    {
        loadingBar.value = 0;
        StartCoroutine(load());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator load()
    {
        while (loadingBar.value < 30)
        {
            loadingBar.value += 0.6f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        while (loadingBar.value <= 63)
        {
            loadingBar.value += 0.6f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(1f);
        while (loadingBar.value <= 77)
        {
            loadingBar.value += 0.6f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(1f);
        while (loadingBar.value < 92)
        {
            loadingBar.value += 1f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.2f);
        while (loadingBar.value < 100)
        {
            loadingBar.value += 0.5f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nextScene);
    }
}
